TwoTapNet
=========

.NET SDK for TwoTap (http://twotap.com)


## Code Example

```csharp

ITwoTapClient client = new TwoTapClient("<api_token>", "<private_api_token>", TwoTapClient.eMode.FAKE_CONFIRM);

AddToCartRequest request = new AddToCartRequest();
request.Products = new List<string>();
request.Products.Add("<url_to_product");

var response = client.AddToCart(request);

```