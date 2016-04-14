Imports DotNetNuke.Web.Api

Public Class MyAuthorization
    Inherits AuthorizeAttributeBase
    Public Overrides Function IsAuthorized(context As AuthFilterContext) As Boolean
        Dim headers = context.ActionContext.Request.Headers
        If headers.Contains("APIKEY") Then
            Return True
        End If

        Return False
    End Function


End Class
