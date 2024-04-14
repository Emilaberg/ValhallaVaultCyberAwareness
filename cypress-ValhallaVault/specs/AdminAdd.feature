Feature: AdminAdd

Background: 
Given that I am logged in

Scenario: Navigate to add category
When I am on the admin page
And i click on the Go to Add button
Then I should see "AdminAdd" on the add page

Scenario: Add category
When I am on the add page
And I type "Test category" in the category name field
And I Click on the add new category button
Then I should see "Test category" on the admin page