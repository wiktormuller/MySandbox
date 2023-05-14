var cloakCounterSpan = document.getElementById("cloakCounter");
var stoneCounterSpan = document.getElementById("stoneCounter");
var wandCounterSpan = document.getElementById("wandCounter");

// Create connection
var connectionDeathlyHallows = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/deathlyhallows", signalR.HttpTransportType.WebSockets)
    .build();
//var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HttpTransportType.ServerSentEvents).build(); // Responses from server are send via one-way connection
//var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HttpTransportType.LongPolling).build(); // Request is pending for some time for any response, and after some timeout new polling request is created and waiting for responses

// Connect to methods that hub invokes aka receive notifications from Hub
connectionDeathlyHallows.on("updateDeathlyHallowsCount", (cloak, stone, wand) => { // This method is called from backend controller to update the UI
    cloakCounterSpan.innerText = cloak;
    stoneCounterSpan.innerText = stone;
    wandCounterSpan.innerText = wand;
});

// Start Connection
function fulfilled() {
    // Do something on start
    console.log("Connection to User Hub Successful");
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {
        cloakCounterSpan.innerText = raceCounter.cloak;
        stoneCounterSpan.innerText = raceCounter.stone;
        wandCounterSpan.innerText = raceCounter.wand;
    })
}

function rejected() {
    // Rejected logs
    console.log("Connection to User Hub was rejected");
}

connectionDeathlyHallows.start().then(fulfilled, rejected);