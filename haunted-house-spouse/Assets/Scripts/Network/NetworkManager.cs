using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NetworkView))]
public class NetworkManager : MonoBehaviour {

	readonly string gameName = "haunted-house-spouse";
	HostData[] hosts = new HostData[0];
	string debugText = "";
	struct Settings {

		public int maxConnections;
		public bool secureServer;
		public float timeoutDuration;

		public Settings (int maxConnections = 6, bool secureServer = false, float timeoutDuration = 10f) {
			this.maxConnections = maxConnections;
			this.secureServer = secureServer;
			this.timeoutDuration = timeoutDuration;
		}
	}
	Settings settings;

	public static bool Ghost {
		get { return Network.isClient; }
	}

	void Awake () {
		settings = new Settings (6, false, 5f);
		MasterServer.ClearHostList ();
		RefreshHostList ();
	}

	/**
	 *	Hosting
	 */

	void StartServer (string gameInstanceName) {
		if (settings.secureServer)
			Network.InitializeSecurity ();

		// Use NAT punchthrough if no public IP present
		Network.InitializeServer (settings.maxConnections, 25001, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (gameName, gameInstanceName);
		debugText = "server started";
	}

	public void StopServer () {
		Network.Disconnect ();
		MasterServer.UnregisterHost ();
		ResetHosts ();
	}

	/**
	 *	Joining
	 */

	void RefreshHostList () {
		MasterServer.RequestHostList (gameName);
		StartCoroutine (FindHosts ());
	}

	// Attempts to find a host and join. If it fails then it starts a server.
	IEnumerator FindHosts () {

		ResetHosts ();
		float timeout = settings.timeoutDuration;

		while (hosts.Length == 0 && timeout > 0f) {
			hosts = MasterServer.PollHostList ();
			timeout -= Time.deltaTime;
			yield return null;
		}

		if (timeout <= 0f) {
			OnTimeout ();
		} else {
			OnFoundGames ();
		}
	}

	void OnTimeout () {
		debugText = "no games found. starting server...";
		StartServer ("test");
	}

	void OnFoundGames () {
		Network.Connect (hosts[0]);
		debugText = string.Format ("found {0} games. connecting...", hosts.Length);
		StartCoroutine (CoConnectAdvance ());
	}

	IEnumerator CoConnectAdvance () {
		float timeout = settings.timeoutDuration;
		while (!Network.isClient && timeout > 0f) {
			timeout -= Time.deltaTime;
			yield return null;
		}
		if (timeout <= 0f) {
			debugText = "disconnected";
		} else {
			networkView.RPC ("OnConnect", RPCMode.All);
		}
	}

	void ResetHosts () {
		hosts = new HostData[0];
	}

	void OnGUI () {
		//GUILayout.Label (debugText);
		GUILayout.Label ("loading. give it a couple secs.");
	}

	void OnApplicationQuit () {
		StopServer ();
	}

	[RPC] void OnConnect () {
		Application.LoadLevel ("House");
	}
}
