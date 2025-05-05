Feature: Tasks
	As an admin
	I want to manage the website
	So that I can create tasks

    Scenario: Successfully create a task with required fields
        Given I am logged into the system
        And I opened the Project Management tab
        And I opened My Opened Project tasks module
        When I click the Create button
        And I enter task name
        And I select start and due dates
        And I select a project
        And I leave the default status
        When I save the task
        Then I should be able to find task using search
        Then The task should be visible with correct name
        And Task should have correct project
        And Task should have correct dates
        And Task should have correct status