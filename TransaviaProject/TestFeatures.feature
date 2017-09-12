Feature: TestFeatures

Scenario: Search flight based on booking number

Given I'm on the Transavia Online check-in page
And I have entered all mandatory fields
When I press on the Log In button
Then the information of the desired booking should appear


Scenario: Booking number field shoud't allow more than 12 characters

Given I'm on the Transavia Online check-in page
And I have entered a booking number with 13 characters
When I press on the Log In button
Then the user should get a warning message that the field doesn't allow more than 12 characters