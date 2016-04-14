

Imports DotNetNuke.Web.Api

Public Class GemStoreServices
    Implements IServiceRouteMapper

    Public Sub RegisterRoutes(mapRouteManager As IMapRoute) Implements IServiceRouteMapper.RegisterRoutes
        mapRouteManager.MapHttpRoute("Angular_Gem_Store", "default", "{controller}/{action}", {"Kb.Dnn.Angular_Gem_Store"})
    End Sub
End Class
