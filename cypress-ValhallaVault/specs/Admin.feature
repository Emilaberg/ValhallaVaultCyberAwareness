Feature: Admin

Background: 
Given that I am logged in

Scenario: navigate to admin
When I am on the Admin page
Then The categories should be Visible

Scenario: select category
When I am on the Admin page
And I click on the category name
Then The modal with category information should be visible



