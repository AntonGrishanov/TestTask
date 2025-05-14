Feature: Tasks
	As an admin
	I want to manage the website
	So that I can create tasks

    Scenario: Successfully create a task with required fields
        Given I am logged into the system
        And I've opened the Project Management tab
        And I've opened My Opened Project tasks module
        When I click the Create button
        And I enter task name
        And I select start and due dates
        And I select a project
        And I leave the default status
        When I save the task
        And I click Return to list button
        When I search for a task using search
        Then The task should be visible with correct name
        And Task should have correct project
        And Task should have correct dates
        And Task should have correct status