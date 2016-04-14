<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="View.ascx.vb" Inherits="Kb.Dnn.Angular_Gem_Store.View" %>

<div ng-app="gemStore">
    <h1>{{"Angular Module!"}}</h1>
    <div ng-controller="StoreController as store" ng-init="store.init(<%=ModuleId%>,'<%=ModuleContext.Configuration.DesktopModule.ModuleName%>')" >
        <%--<base href="<%= ResourcePath %>"></base>--%>
        <h4>{{store.Title}}</h4>
        <product-chart-line></product-chart-line>
        <product-chart-polar></product-chart-polar> 
        <product-chart-bar></product-chart-bar>
        
        
        <ul class="list-group">
            <li class="list-group-item" ng-repeat="product in store.Products | orderBy:'Price'" ng-hide="product.soldOut">
                <product-title></product-title>
                <product-gallery></product-gallery>
                <%--<button class="pull-right" ng-show="product.canPurchase">Add to Cart</button>--%>
                <product-panels></product-panels>
            </li>
        </ul>


    </div>
</div>
 <p></p>

