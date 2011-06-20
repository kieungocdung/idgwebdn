﻿'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2010
' by DotNetNuke Corporation
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'


Namespace DotNetNuke.Services.Messaging.Data
    Public Interface IMessagingDataService
        Function GetMessageByID(ByVal MessageID As Integer) As IDataReader
        Function GetUserInbox(ByVal PortalID As Integer, ByVal UserID As Integer, ByVal PageNumber As Integer, ByVal PageSize As Integer) As IDataReader
        Function GetInboxCount(ByVal PortalID As Integer, ByVal UserID As Integer) As Integer
        Function SaveMessage(ByVal objMessaging As Message) As Long
        Function GetNewMessageCount(ByVal PortalID As Integer, ByVal UserID As Integer) As Integer
        Function GetNextMessageForDispatch(ByVal SchedulerInstance As Guid) As IDataReader
        Sub MarkMessageAsDispatched(ByVal MessageID As Integer)
        Sub UpdateMessage(ByVal message As Message)
    End Interface
End Namespace