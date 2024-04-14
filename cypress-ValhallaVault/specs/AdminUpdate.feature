Feature: Admin Update

Background: 
Given that I am logged in

Scenario: Update category
When I am on the admin page
And I Click on the "Test category" category
And The modal with category information is visible
And I type "Category Test" in the input field 
And I click on the save changes button
Then I should see "Category Test" on the admin page