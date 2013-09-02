using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider_CRUD_Example.Entity;
using MvcSiteMapProvider;

namespace MvcSiteMapProvider_CRUD_Example.SiteMapProvider
{
    public class ProductDynamicNodeProvider
        : DynamicNodeProviderBase
    {
        CRUDExample db = new CRUDExample();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var result = new List<DynamicNode>();
            
            var products = db.Product;
            foreach (var product in products)
            {
                var productKey = "Product_" + product.Id.ToString();

                // Create the "Details" node for the product
                var productNode = new DynamicNode(productKey, "Products", product.Name, product.Name, "Product", "Details");
                
                // Set the "id" route value so the match will work.
                productNode.RouteValues.Add("id", product.Id);

                // Set our visibility. This will override what we have configured on the DynamicProducts node. We need to 
                // do this to ensure our products are visible in the /sitemap.xml path.
                productNode.Attributes["visibility"] = "SiteMapPathHelper,XmlSiteMapResult,!*";

                // Add the node to the result
                result.Add(productNode);


                // Create the "Edit" node for the product
                var productEditNode = new DynamicNode("ProductEdit_" + product.Id.ToString(), productKey, "Edit", "Edit", "Product", "Edit");

                // Set the "id" route value of the edit node
                productEditNode.RouteValues.Add("id", product.Id);

                // Add the node to the result
                result.Add(productEditNode);


                // Create the "Delete" node for the product
                var productDeleteNode = new DynamicNode("ProductDelete_" + product.Id.ToString(), productKey, "Delete", "Delete", "Product", "Delete");

                // Set the "id" route value of the delete node
                productDeleteNode.RouteValues.Add("id", product.Id);

                // Add the node to the result
                result.Add(productDeleteNode);
            }

            return result;
        }
    }
}