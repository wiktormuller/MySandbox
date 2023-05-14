// Create connection
var connectionUserCount = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/userCount", signalR.HttpTransportType.WebSockets)
    .build();
//var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HttpTransportType.ServerSentEvents).build(); // Responses from server are send via one-way connection
//var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HttpTransportType.LongPolling).build(); // Request is pending for some time for any response, and after some timeout new polling request is created and waiting for responses

// Connect to methods that hub invokes aka receive notifications from Hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value;
});

connectionUserCount.on("updateTotalUsers", (value) => { // This is called from the backend Hub
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value;
});

// Invoke Hub methods aka send notification to hub
function newWindowLoadedOnClient() { // This method is called when we create new connection
    connectionUserCount.invoke("NewWindowLoaded", "SomeInputArgument").then((value) => {
        console.log(value);
    }); // When we use .send method we cannot get any response from hub, but we can use .invoke method to get some response data
}

// Start Connection
function fulfilled() {
    // Do something on start
    console.log("Connection to User Hub Successful");
    newWindowLoadedOnClient();
}

function rejected() {
    // Rejected logs
    console.log("Connection to User Hub was rejected");
}

connectionUserCount.start().then(fulfilled, rejected);