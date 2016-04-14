' Copyright (c) 2016  Kyle
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports System.Globalization
Imports System.Xml
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Search.Entities

Namespace Components

    ''' <summary>
    ''' The Controller class for Angular_Gem_Store
    ''' 
    ''' The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    ''' DotNetNuke will poll this class to find out which Interfaces the class implements. 
    ''' 
    ''' The IPortable interface is used to import/export content from a DNN module
    ''' 
    ''' The ISearchable interface is used by DNN to index the content of a module
    ''' 
    ''' The IUpgradeable interface allows module developers to execute code during the upgrade 
    ''' process for a module.
    ''' 
    ''' Below you will find stubbed out implementations of each, uncomment and populate with your own data
    ''' </summary>
    Public Class FeatureController
        Inherits ModuleSearchBase
        'Implements IPortable
        'Implements IUpgradeable
        ' feel free to remove any interfaces that you don't wish to use
        ' (requires that you also update the .dnn manifest file)

#Region " Optional Interfaces "

        ''' <summary>
        ''' Gets the modified search documents for the DNN search engine indexer.
        ''' </summary>
        ''' <param name="moduleInfo">The module information.</param>
        ''' <param name="beginDate">The begin date.</param>
        ''' <returns></returns>
        Public Overrides Function GetModifiedSearchDocuments(moduleInfo As ModuleInfo, beginDate As DateTime) As IList(Of SearchDocument)
            Dim searchDocuments = New List(Of SearchDocument)()


            Return searchDocuments
        End Function



#End Region

    End Class

End Namespace