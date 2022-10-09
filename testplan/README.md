## Test Plan
### Subject: 

https://www.belk.com/p/madison-slim-fit-dynamic-cooling-stretch-dress-shirt/320164011M0070.html?dwvar_320164011M0070_color=050330628212#start=1

### Test Feature: 
**Product Image Zoom**
- When hovering over an image, a zoom window appears to the right of the image with a magnified view of the image
- When clicking on an image, a zoom popup box appears in the center of page

### Description:

https://www.belk.com/ is online shopping website for the department store, Belk. I discovered this site while randomly shopping online one day and thought it would make a good subject for a test plan since it had noticable bugs. This test plan applies to pretty much any product page on the site, but I used a specific example to make testing easier to follow. This test covers the functionality and usability of the Product Image Zoom when viewing on desktop browser. It does not cover testing on a mobile environment. 



### Preconditions:
Desktop web browser, live internet connection

### Test Environment Used: 
OS: Windows 10 Home Edition, Version 21H1, Build: 19043.2006

Chrome Browser: Version 105.0.5195.127 (Official Build) (64-bit)

## Test cases:

#### TC1: Zoom-On-Hover

Test type: functionality test

##### Steps:
1. Go to subject link
2. Hover over the largest product image with cursor

##### Expected Result:
Hovering over a product image reveals a zoom window that appears to the right. The zoom window shows a magnified view of the image that tracks along with the cursor.

##### Actual Result:
Same as expected.

[zoom-on-hover.webm](https://user-images.githubusercontent.com/54592360/194748045-f028ce33-bc47-4927-bc56-53c4dc3cc12a.webm)

---

#### TC2: Zoom-On-Click

Test type: functionality test

##### Steps:
1. Go to subject link
2. Click on the largest product image with cursor 

##### Expected Result:
Clicking on the product image opens up a pop-up window containing the image and buttons for zoom-in, zoom-out, and exit. 

##### Actual Result:
Same as expected.

[zoom-on-click.webm](https://user-images.githubusercontent.com/54592360/194748347-7233daaa-5ea2-4310-8117-bdfad3e7bc5e.webm)

---
 

#### TC3: Zoom-On-Hover-Off-Bug

Test type: functionality test, exploratory test

##### Steps:
1. Go to subject link
2. Set browser zoom to 75%
3. Click on largest product image to reveal the zoom pop-up window
4. Click off of the pop-up window to close it
5. Click on the bottom thumbnail located on the left side of the active image
6. Hover over the active image to reveal the zoom window to the right
7. Move cursor to the bottom and off of the image

##### Expected Result:
The zoom window should disappear when the cursor is no longer hovering over the image


##### Actual Result:
**BUG:** The zoom window flashes on and off when the cursor is off the image

https://user-images.githubusercontent.com/54592360/194747709-b41d4e61-fdab-46b3-a485-165f4ca05f12.mp4

--- 

#### TC4: Zoom-On-Click-Buttons-Work

Test type: functionality test

##### Steps:
1. Go to subject link
2. Click on the largest product image with cursor to reveal the zoom pop-up
3. Click the zoom-in button "+"
4. Click the zoom-out button "-"
5. Click the next arrow button ">"
6. Click the previous arrow button "<"
7. Click the exit pop-up button "X" 

##### Expected Result:
Zoom-in button magnifies a portion the image while zoom-out does the opposite. Next button goes to the next image (if available) while previous button does the opposite. Exit button closes the zoom pop-up.

##### Actual Result:
Same as expected.

[zoom-on-click-buttons-work.webm](https://user-images.githubusercontent.com/54592360/194748962-c25f52c1-29f9-4542-88de-62e1ab40ccf5.webm)

--- 

#### TC5: Zoom-On-Click-Drag

Test type: functionality test

##### Steps:
1. Go to subject link
2. Click on the largest product image with cursor to reveal the zoom pop-up
3. Click the zoom-in button "+"
4. Drag the cursor over the image in all four directions: up, down, left, and right
5. Click the zoom-in button "+" again
6. Once again drag over the image


##### Expected Result:
Dragging over the image with the cursor moves the magnified view respective to the drag direction

##### Actual Result:
Same as expected.

[zoom-on-click-drag.webm](https://user-images.githubusercontent.com/54592360/194749385-fb72fac3-5148-4c0e-ae8e-900aaafcb16c.webm)

---


