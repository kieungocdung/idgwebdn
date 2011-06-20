﻿'
' DotNetNuke - http://www.dotnetnuke.com
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

Imports DotNetNuke.Entities.Content.Taxonomy

Namespace DotNetNuke.Modules.Taxonomy.Views.Models

    Public Class VocabularyListModel

        Private _IsEditable As Boolean
        Private _NavigateUrlFormatString As String
        Private _Vocabularies As IList(Of Vocabulary)

        Public Property IsEditable() As Boolean
            Get
                Return _IsEditable
            End Get
            Set(ByVal value As Boolean)
                _IsEditable = value
            End Set
        End Property

        Public Property NavigateUrlFormatString() As String
            Get
                Return _NavigateUrlFormatString
            End Get
            Set(ByVal value As String)
                _NavigateUrlFormatString = value
            End Set
        End Property

        Public Property Vocabularies() As IList(Of Vocabulary)
            Get
                Return _Vocabularies
            End Get
            Set(ByVal value As IList(Of Vocabulary))
                _Vocabularies = value
            End Set
        End Property

    End Class
End Namespace
