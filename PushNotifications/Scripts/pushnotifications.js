function InboundMessage(from, to, text, accountId) {
    var self = this;
    self.from = from;
    self.to = to;
    self.text = text;
    self.accountId = accountId;
}

function DeliveredMessage(occurredAt, messageId, accountId) {
    var self = this;
    self.occurredAt = occurredAt;
    self.messageId = messageId;
    self.accountId = accountId;
}

function AppMessage(username, password, account, notificationType, id, originator, recipient, body, type, sentAt, receivedAt) {
    var self = this;
    self.username = username;
    self.password = password;
    self.account = account;
    self.notificationType = notificationType;
    self.id = id;
    self.originator = originator;
    self.recipient = recipient;
    self.body = body;
    self.type = type;
    self.sentAt = sentAt;
    self.receivedAt = receivedAt;
}

function AppViewModel() {
    var self = this;
    self.inboundMessages = ko.observableArray([]);
    self.addInboundMessage = function (m) {
        var message = new InboundMessage(m.From, m.To, m.MessageText, m.AccountId);
        self.inboundMessages.push(message);
    }

    self.deliveredMessages = ko.observableArray([]);
    self.addDeliveredMessage = function (m) {
        var message = new DeliveredMessage(m.OccurredAt, m.MessageId, m.AccountId);
        self.deliveredMessages.push(message);
    }

    self.appMessages = ko.observableArray([]);
    self.addAppMessage = function (m) {
        var message = new AppMessage(m.username, m.password, m.account, m.notificationType, m.id, m.originator, m.recipient, m.body, m.type, m.sentAt, m.receivedAt);
        self.appMessages.push(message);
    }
}

$(document).ready(function () {
    var viewModel = new AppViewModel();
    ko.applyBindings(viewModel);

    var hub = $.connection.messagesHub;
    hub.client.addNewInboundMessageToPage = function (message) {
        viewModel.addInboundMessage(message);
    };

    hub.client.addNewDeliveredMessageToPage = function (message) {
        viewModel.addDeliveredMessage(message);
    };

    hub.client.addNewAppMessageToPage = function (message) {
        viewModel.addAppMessage(message);
    };

    $.connection.hub.start();
});