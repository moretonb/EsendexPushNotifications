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

    $.connection.hub.start();
});