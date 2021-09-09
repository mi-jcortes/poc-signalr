// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationhub").build();

connection
    .start()
    .then(function () {
        return console.log("Conectado!!!");
    })
    .catch(function (e) {
        return console.error(e.toString());
    });

document.getElementById("eventBtn").onclick = sendEvent;

function sendEvent() {
    const message = document.getElementById("eventMessage").value;
    connection
        .invoke("SendMessage", message)
        .catch(function (err) {
            return console.error(err.toString());
        });
};

document.getElementById("pushEventBtn").onclick = sendPushEvent;

function sendPushEvent() {
    const payload = {
        "notification": {
            "title": "Hola!",
            "body": "Saludos desde el servicio NEXCEL PUSH",
            "vibrate": [100, 50, 100],
            "actions": [{
                "action": "explore",
                "title": "Go to the site"
            }]
        }
    };

    fetch('http://localhost:5000/push', {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
    }).then(function (response) {
        console.log(response);
    }).catch(function (error) {
        console.log('Failed to store the Push Notifications subscription on server: ' + error);
    });


}

connection.on("RecieveMessage", function (message) {
    console.log("Mensaje", message);
});