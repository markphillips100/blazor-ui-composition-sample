# blazor-ui-composition-sample

Sample applications to showcase different UI composition approaches.  These are not intended to by micro-frontends, but to attempt to keep as much business UI rendering and state logic within the business boundary without coupling with any other business boundary.

Discussion is welcome.

## Usage

Set a ```<name>.Server``` project as startup project, F5 to debug, select Orders from the left menu.

- WebApp uses the DynamicComponent approach.
- WebApp2 uses the template approach.

Both approaches use viewmodel composition to build a model from a single api call.

## DynamicComponent Approach

WebApp project makes use of a page component from the Sales service.  This page uses a Blazor DynamicComponent to render a blazor component from another service boundary (Catalog).  Whilst there's no compile-time dependency for this UI composition approach, there is knowledge leaking from the Catalog domain into the Sales domain as the fully qualified name and component parameter contract must be known to Sales UI components.

## Template Approach

WebApp2 project does not use any dynamic component.  Instead, it makes the app responsible for the ```/orders``` page and how to construct the components it wants, starting with the Orders component from Sales.  This component is only responsible for the following:

1. building composition model state, 
2. making the composition model available for child components, and 
3. extracting keys from the model so that child components can index their data.

This approach also makes the responsibility of how to layout components solely with the app's page rather than any single service boundary.  As an example, 2 approaches are shown; one using a general card-style layout, and another using table layout.  The latter requires usage of service components that know how to render table headers and rows.