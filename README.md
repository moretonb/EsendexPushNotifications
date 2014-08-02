EsendexPushNotifications
========================

A simple web app to handle Esendex push notifications and app notifications created with ASP.NET MVC, Web Api 2, Knockout, SignalR and JQuery

example raw input to post to the inbound message controller
-------------------------------------------------------------------
```xml
<InboundMessage>
 <Id>bece4d20-779c-4778-b08c-438a13cca5c9</Id>
 <MessageId>ee931a29-d176-42bb-b2a1-a66871e8c118</MessageId>
 <AccountId>6145d724-98cb-41a2-8c4e-4b81ef694897</AccountId>
 <MessageText>some text</MessageText>
 <From>123123123</From>
 <To>456456456</To>
</InboundMessage>
```

example raw input to post to the delivered messages controller
----------------------------------------------------------------------
```xml
<MessageDelivered>
 <Id>bece4d20-779c-4778-b08c-438a13cca5c9</Id>
 <MessageId>ee931a29-d176-42bb-b2a1-a66871e8c118</MessageId>
 <AccountId>6145d724-98cb-41a2-8c4e-4b81ef694897</AccountId>
 <OccurredAt>2014-07-31T21:42:46</OccurredAt>
</MessageDelivered>
```

example form to post to the app messages controller
---------------------------------------------------
```xml
<FORM method="post" action="<<your uri here>>"><INPUT type="Hidden" name="username" value="TestUser">
<INPUT type="Hidden" name="password" value="TestPassword">
<INPUT type="Hidden" name="account" value="TestAccount">
<INPUT type="Hidden" name="notificationType" value="MessageReceived">
<INPUT type="Hidden" name="id" value="c9b1ed7b-2ad2-4b45-85cf-63f430aab76a">
<INPUT type="Hidden" name="originator" value="447800123456">
<INPUT type="Hidden" name="recipient" value="447800000000">
<INPUT type="Hidden" name="body" value="Test">
<INPUT type="Hidden" name="type" value="Text">
<INPUT type="Hidden" name="sentAt" value="2014-08-02 16:28:42Z">
<INPUT type="Hidden" name="receivedAt" value="2014-08-02 16:28:42Z"></FORM>
```
