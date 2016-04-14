' Copyright (c) 2016  Kyle
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
Imports DotNetNuke
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports Kb.Dnn.Angular_Gem_Store.Components
Imports DotNetNuke.UI.Utilities
Imports DotNetNuke.Framework.JavaScriptLibraries
Imports DotNetNuke.Web.Client.ClientResourceManagement

''' <summary>
''' The View class displays the content
''' 
''' Typically your view control would be used to display content or functionality in your module.
''' 
''' View may be the only control you have in your project depending on the complexity of your module
''' 
''' Because the control inherits from Angular_Gem_StoreModuleBase you have access to any custom properties
''' defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
''' 
''' </summary>
Partial Class View
    Inherits Angular_Gem_StoreModuleBase
    Implements IActionable

    Public ReadOnly Property ResourcePath As String
        Get
            Return ControlPath & "Resources/"
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            'Dim tc As New ItemController()
            'rptItemList.DataSource = tc.GetItems(ModuleId)
            'rptItemList.DataBind()

        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub

    Private Sub View_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        JavaScript.RequestRegistration("AngularJS")
        JavaScript.Register(Page)

        ClientResourceManager.RegisterStyleSheet(Page, ControlPath & "Resources/css/bootstrap.min.css")
        ClientResourceManager.RegisterStyleSheet(Page, ControlPath & "Resources/css/angular-chart.css")

        ClientResourceManager.RegisterScript(Page, ControlPath & "Resources/js/app.js")
        ClientResourceManager.RegisterScript(Page, ControlPath & "Resources/js/products.js")
        ClientResourceManager.RegisterScript(Page, ControlPath & "Resources/js/charts/Chart.js")
        ClientResourceManager.RegisterScript(Page, ControlPath & "Resources/js/charts/angular-chart.js")


    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Registers the module actions required for interfacing with the portal framework
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ModuleActions() As ModuleActionCollection Implements IActionable.ModuleActions
        Get
            Dim Actions As New ModuleActionCollection
            Actions.Add(GetNextActionID, Localization.GetString("EditModule", LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
            Return Actions
        End Get
    End Property


End Class