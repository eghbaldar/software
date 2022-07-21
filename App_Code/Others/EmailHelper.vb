Imports Microsoft.VisualBasic
Imports System.Net.Mail

'
'========================================================================================
'========================================================================================
'========================================================================================


'Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click

'    'Create instance of main mail message class.
'    Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()

'    'Configure mail mesage
'    'Set the From address with user input
'    '    mailMessage.From = New System.Net.Mail.MailAddress(txtFromAddress.Text.Trim())
'    'Get From address in web.config
'    mailMessage.From = New System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings("fromEmailAddress"))
'    'Another option is the "from" attirbute in the <smtp> element in the web.config.

'    'Set additinal addresses
'    mailMessage.To.Add(New System.Net.Mail.MailAddress(txtToAddress.Text.Trim()))
'    'mailMessage.CC
'    'mailMessage.Bcc
'    'mailMessage.ReplyTo

'    'Set additional options
'    mailMessage.Priority = Net.Mail.MailPriority.High
'    'Text/HTML
'    mailMessage.IsBodyHtml = False

'    'Set the subjet and body text
'    mailMessage.Subject = txtSubject.Text.Trim()
'    mailMessage.Body = txtBody.Text.Trim()

'    'Add one to many attachments
'    'mailMessage.Attachments.Add(New System.Net.Mail.Attachment("c:\temp.txt")

'    'Create an instance of the SmtpClient class for sending the email
'    Dim smtpClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()

'    'Use a Try/Catch block to trap sending errors
'    'Especially useful when looping through multiple sends
'    Try
'        smtpClient.Send(mailMessage)
'    Catch smtpExc As System.Net.Mail.SmtpException
'        'Log error information on which email failed.
'    Catch ex As Exception
'        'Log general errors
'    End Try

'End Sub

'========================================================================================
'========================================================================================
'========================================================================================


'Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)

'    Dim msg As New MailMessage()

'    msg.To = "das@silicomm.com"
'    msg.From = "das@aspalliance.com"
'    msg.Subject = "test"
'    'msg.BodyFormat = MailFormat.Html
'    msg.BodyFormat = MailFormat.Text
'    msg.Body = "hi"

'    msg.Attachments.Add(New MailAttachment(Server.MapPath("EMAIL1.ASPX")))

'    SmtpMail.SmtpServer = "localhost"

'    SmtpMail.Send(msg)
'    msg = Nothing
'    lblMsg.Text = "An Email has been send to " & "das@silicomm.com"

'End Sub

'========================================================================================
'========================================================================================
'========================================================================================

Public Class EMailHelper
    ''' <summary>
    ''' Sends an mail message
    ''' </summary>
    ''' <param name="from">Sender address</param>
    ''' <param name="recepient">Recepient address</param>
    ''' <param name="bcc">Bcc recepient</param>
    ''' <param name="cc">Cc recepient</param>
    ''' <param name="subject">Subject of mail message</param>
    ''' <param name="body">Body of mail message</param>
    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String)
        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(from)
        ' Set the recepient address of the mail message
        mMailMessage.To.Add(New MailAddress(recepient))

        ' Check if the bcc value is nothing or an empty string
        If Not bcc Is Nothing And bcc <> String.Empty Then
            ' Set the Bcc address of the mail message
            mMailMessage.Bcc.Add(New MailAddress(bcc))
        End If

        ' Check if the cc value is nothing or an empty value
        If Not cc Is Nothing And cc <> String.Empty Then
            ' Set the CC address of the mail message
            mMailMessage.CC.Add(New MailAddress(cc))
        End If

        ' Set the subject of the mail message
        mMailMessage.Subject = subject
        ' Set the body of the mail message
        mMailMessage.Body = body

        ' Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = True
        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal

        Try
            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()
            ' Send the mail message
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try

    End Sub


    'Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click

    '    'Create instance of main mail message class.
    '    Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()

    '    'Configure mail mesage
    '    'Set the From address with user input
    '    '    mailMessage.From = New System.Net.Mail.MailAddress(txtFromAddress.Text.Trim())
    '    'Get From address in web.config
    '    mailMessage.From = New System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings("fromEmailAddress"))
    '    'Another option is the "from" attirbute in the <smtp> element in the web.config.

    '    'Set additinal addresses
    '    mailMessage.To.Add(New System.Net.Mail.MailAddress(txtToAddress.Text.Trim()))
    '    'mailMessage.CC
    '    'mailMessage.Bcc
    '    'mailMessage.ReplyTo

    '    'Set additional options
    '    mailMessage.Priority = Net.Mail.MailPriority.High
    '    'Text/HTML
    '    mailMessage.IsBodyHtml = False

    '    'Set the subjet and body text
    '    mailMessage.Subject = txtSubject.Text.Trim()
    '    mailMessage.Body = txtBody.Text.Trim()

    '    'Add one to many attachments
    '    'mailMessage.Attachments.Add(New System.Net.Mail.Attachment("c:\temp.txt")

    '    'Create an instance of the SmtpClient class for sending the email
    '    Dim smtpClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()

    '    'Use a Try/Catch block to trap sending errors
    '    'Especially useful when looping through multiple sends
    '    Try
    '        smtpClient.Send(mailMessage)
    '    Catch smtpExc As System.Net.Mail.SmtpException
    '        'Log error information on which email failed.
    '    Catch ex As Exception
    '        'Log general errors
    '    End Try

    'End Sub

End Class


