Feature: Admin Delete

Background: 
Given that I am logged in

Scenario: Delete category
When I am on the admin page
And I Click on the "Category Test" category
And The modal with category information is visible
And I click on the delete button
And the confirmation modal is visible
And I click on the yes button
Then I should not see "Category Test" on the admin page