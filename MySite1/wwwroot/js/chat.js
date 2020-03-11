var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/Messages/Index")
    .build();

//document.getElementById("sendBtn").disabled = true;
let userName = document.getElementById("userName").value;
// получение
hubConnection.on('Send', function (user, message) {
    // создаем элемент <b> для имени пользователя
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(user + ': '));

    // создает элемент <p> для сообщения пользователя
    let elem = document.createElement("p");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    var firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(elem, firstElem);
});

// отправка сообщения на сервер
document.getElementById("sendBtn").addEventListener("click", function (e) {
    let message = document.getElementById("messageInput").value;
    hubConnection.invoke("Send", message, userName);
    document.getElementById("messageInput").value = '';
});

hubConnection.start();