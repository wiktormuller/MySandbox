// Create connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

// Connect to methods that hub invokes aka receive notifications from Hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value;
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value;
});

// Invoke Hub methods aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
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