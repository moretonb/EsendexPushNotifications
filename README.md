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

example raw input to post to the delivered message controller
----------------------------------------------------------------------
```xml
<MessageDelivered>
 <Id>bece4d20-779c-4778-b08c-438a13cca5c9</Id>
 <MessageId>ee931a29-d176-42bb-b2a1-a66871e8c118</MessageId>
 <AccountId>6145d724-98cb-41a2-8c4e-4b81ef694897</AccountId>
 <OccurredAt>2014-07-31T21:42:46</OccurredAt>
</MessageDelivered>
```

example raw input to post to the optout controller
----------------------------------------------------------------------
```xml
<OptOut>
  <Id>436332c6-8755-41bf-abde-cc48eafacba0</Id>
  <AccountId>f6462f9d-87a2-4cac-97a6-5a2d9cb81997</AccountId>
  <AccountReference>EX0010000</AccountReference>
  <ReceviedAt>2015-11-09T15:18:19Z</ReceviedAt>
  <From>
     <PhoneNumber>447728693111</PhoneNumber>
  </From>
  <Link rel="optout" href="https://api.esendex.com/v1.0/optouts/436332c6-8755-41bf-abde-cc48eafacba0" />
</OptOut>
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
