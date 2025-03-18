<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="YourNamespace.Contact" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Contact Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Contact Us</h2>
            <label for="Name">Name:</label>
            <input type="text" id="Name" runat="server" required /><br /><br />

            <label for="Email">Email:</label>
            <input type="email" id="Email" runat="server" required /><br /><br />

            <label for="Message">Message:</label><br />
            <textarea id="Message" runat="server" rows="5" required></textarea><br /><br />

            <button type="submit" runat="server" onserverclick="SendMessage_Click">Send</button>
        </div>
    </form>
</body>
</html>
