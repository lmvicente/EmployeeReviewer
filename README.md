# EmployeeReviewer
Using C#, Entity Framework, HTML/CSS (Bootstrap), MVC pattern, and SQL I created an Employee Reviewer web application. With this web application, you can input all your employees, departments, and job titles into the SQL database. From there, you can select the employees who are able to review employees. Using Entity Framework, this is then setup for you to easily leave reviews for each of your employees. 

![EmployeeReviewer](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17.png)

### Searching The Table
![SearchingTable](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17.gif)
Within the ReviewsController you will find within the Index function that it takes in 2 strings, SearchName and ReviewerName. These are the names of the two textoxes as seen in the GIF above. If the value of the textboxes are not null or empty, it will use the strings to search the view, vw_AllReviews, and return the results that match.

### Creating A Review
![CreatingReview](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17%20(1).gif)
Within the ReviewsController there is the ability to create a review. Entity Framework can easily pull the necessary fields through the model is auto-generated from the database connection. 

### Editing A Review
![EditingReview](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17%20(2).gif)
Entity Framework, and other ORMs, also give you the ability to Update existing entries. Using the ID it pulls from the displayed table, it is able to create a route that will provide you editable fields for the review selected.

### Deleting A Review
![DeletingReview](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17%20(3).gif)
Although there is also a Delete View that is operational, I wanted to use the modal that comes from the Bootstrap CSS framework. Grabbing the ID via C#, it is able to differentiate what review is being deleted. For a better experience, and to prevent possible accidents, a modal will pop up and verify that the end user would like to delete the specific review. Close will cancel the action and return to the table. Deleting the review will delete the record for the table.

### Viewing A Review
![ViewingReview](https://raw.githubusercontent.com/lmvicente/EmployeeReviewer/main/GIFs/chrome-capture-2023-1-17%20(4).gif)
Along with the other CUD operations, I finally have R, or read, to complete CRUD. To view a specific review in more detail, you can click on the "View" button to get a closer look at your chosen review.

## Version History
* 0.1 -- 2/17/2023
    * Initial Release

## Things To Add
* 0.2 -- 
    * Ability to add employees without needing to access the database directly 
    * Ability to add and remove selected reviewers without needing to access the database directly 
    * Adjust the deletion of reviews to make it appear inactive instead of deleting the review altogether to keep historical records
