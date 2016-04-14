Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports DotNetNuke.Web.Api

Public Class ItemController
    Inherits DnnApiController

    Private _inventoryRepository As InventoryRepository

    Private Class MessageWrapper(Of T)
        Public Property Message As T
        Public Sub New(msg As T)
            Message = msg
        End Sub
    End Class

    Public Sub New()
        _inventoryRepository = New InventoryRepository
    End Sub

    Protected Function OkResponse(Of T)(message As T) As HttpResponseMessage
        If GetType(T) Is GetType(String) Then
            Return OkResponse(New MessageWrapper(Of T)(message))
        End If
        Return Request.CreateResponse(Of T)(HttpStatusCode.OK, message)
    End Function
    Protected Function ErrorResponse([error] As Exception) As HttpResponseMessage
        Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, [error])
    End Function

    <HttpGet, HttpPost>
    <ActionName("test")>
    <AllowAnonymous>
    Public Function HelloWorld() As HttpResponseMessage
        Return OkResponse("Hello World!")
    End Function

    <HttpGet>
    <ValidateAntiForgeryToken>
    <ActionName("items")>
    Public Function GetInventory() As HttpResponseMessage
        Try
            Dim items = _inventoryRepository.GetItems
            Return OkResponse(items.ToList)
        Catch ex As Exception
            Return ErrorResponse(ex)
        End Try
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    <ActionName("save")>
    <AllowAnonymous>
    Public Function SaveItem(item As IItemModel) As HttpResponseMessage
        Try
            Dim returnItem As IItemModel = _inventoryRepository.SaveItem(item)
            Return OkResponse(returnItem)
        Catch ex As Exception
            Return ErrorResponse(ex)
        End Try

    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    <ActionName("savereview")>
    <AllowAnonymous>
    Public Function SaveReview(review As ItemReview) As HttpResponseMessage
        Try
            Dim item = _inventoryRepository.SaveReview(review)
            Return OkResponse(item)
        Catch ex As Exception
            Return ErrorResponse(ex)
        End Try
    End Function
End Class
