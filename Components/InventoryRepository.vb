Imports DotNetNuke.Data
Imports Kb.Dnn.Angular_Gem_Store

Public Class InventoryRepository

    Public Function GetItems() As IEnumerable(Of IItemModel)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of Item)
            Dim items = rep.Get()
            For Each item In items
                item.Images = GetItemImagePaths(item.RecordId)
                item.Reviews = GetItemReviews(item.RecordId)
            Next

            Return items
        End Using
    End Function

    Public Function GetItemById(itemId As Integer) As Item
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of Item)
            Dim item = rep.GetById(itemId)
            item.Images = GetItemImagePaths(item.RecordId)
            item.Reviews = GetItemReviews(item.RecordId)
            Return item
        End Using
    End Function

    Public Function GetItemImagePaths(itemId As Integer) As IEnumerable(Of IImagePathModel)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of ImagePath)
            Return rep.Find("WHERE ItemId = @0", itemId)
        End Using
    End Function

    Public Function GetItemReviews(itemId As Integer) As IEnumerable(Of IItemReviewModel)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of ItemReview)
            Return rep.Find("WHERE ItemId = @0", itemId)
        End Using
    End Function

    Friend Function SaveItem(item As IItemModel) As IItemModel
        Dim lcItem As Item = CType(item, Item)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of Item)
            If item.RecordId > 0 Then
                rep.Update(lcItem)
            Else
                rep.Insert(lcItem)
            End If

            SaveImagePaths(lcItem)
            SaveReviews(lcItem)
        End Using

        Return lcItem
    End Function

    Private Sub SaveReviews(lcItem As IItemModel)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of ItemReview)
            For Each review As ItemReview In lcItem.Reviews
                review.ItemId = lcItem.RecordId
                If review.RecordId > 0 Then
                    rep.Update(review)
                Else
                    rep.Insert(review)
                End If
            Next
        End Using
    End Sub

    Private Sub SaveImagePaths(lcItem As IItemModel)
        Using dtx = DataContext.Instance
            Dim rep = dtx.GetRepository(Of ImagePath)
            For Each img As ImagePath In lcItem.Images
                img.ItemId = lcItem.RecordId
                If img.RecordId > 0 Then
                    rep.Update(img)
                Else
                    rep.Insert(img)
                End If
            Next
        End Using
    End Sub

    Friend Function SaveReview(review As ItemReview) As Item
        If review.CreatedOn = Date.MinValue Then
            review.CreatedOn = Now
        End If
        Dim dtx = DataContext.Instance
        Dim rep = dtx.GetRepository(Of ItemReview)
        If review.RecordId > 0 Then
            rep.Update(review)
        Else
            rep.Insert(review)
        End If

        Dim item = GetItemById(review.ItemId)
        Return item
    End Function
End Class
