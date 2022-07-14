# blazor-ui-composition-sample

Sample applications to showcase different UI composition approaches.  These are not intended to by micro-frontends, but to attempt to keep as much business UI rendering and state logic within the business boundary without coupling with any other business boundary.

Discussion is welcome.

## Usage

Set a ```<name>.Server``` project as startup project, F5 to debug, select Orders from the left menu.

- WebApp uses the DynamicComponent approach.
- WebApp2 uses the template approach.
- WebApp3 uses a monolithic approach.

All approaches use viewmodel composition to build a model from a single api call.

## DynamicComponent Approach

WebApp project makes use of 2 page components from the Sales service.

- ```/orders``` This page uses a Blazor DynamicComponent to render a blazor component from another service boundary (Catalog).  Whilst there's no compile-time dependency for this UI composition approach, there is knowledge leaking from the Catalog domain into the Sales domain as the fully qualified name and component parameter contract must be known to Sales UI components.
- ```/orders-factory``` This page again use a DynamicComponent to render the same blazor component form the Catalog domain.  However, it makes use of a class to resolve the required type and parameters.  The provider makes an assumption that a key should be provided and is a Guid.  This still gives control of where a catalog component should render its information to the sales domain whilst leaving the how to render the data to the catalog domain, but makes no assumptions about what the static type name of the component is.  Obviously this requires the logical name of the component to be known, e.g. "OrderProductInfo", but it's important to be at least logically specific about the type of component sales wants to render.  If we were to use a different qualifier, like say the page url, then this would not support different rendering requirements on the same page.

## Template Approach

WebApp2 project does not use any dynamic component.  Instead, it makes the app responsible for the ```/orders``` page and how to construct the components it wants, starting with the Orders component from Sales.  This component is only responsible for the following:

1. building composition model state, 
2. making the composition model available for child components, and 
3. extracting keys from the model so that child components can index their data.

This approach also makes the responsibility of how to layout components solely with the app's page rather than any single service boundary.  As an example, 2 approaches are shown; one using a general card-style layout, and another using table layout.  The latter requires usage of service components that know how to render table headers and rows.

## Monolithic Approach

WebApp3 project uses a monolithic approach to the model returned from the viewmodel composition API call.  It combines each service's model into a single model owned by the web app itself and uses this model to render a list of orders using a single component also contained within the webapp.  No service-owned UI components are consumed in this webapp.

NOTE:  This example is provided as an example of how vertical slicing ends at the API layer.  Whilst this does couple services at the UI, it does offer advantages in terms of simpler development with hot reload provided by the toolset.  This may be preferable if a development team is small but may hinder team scaling in the future.