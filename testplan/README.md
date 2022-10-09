## Test Plan
### Subject: 

https://www.belk.com/p/madison-slim-fit-dynamic-cooling-stretch-dress-shirt/320164011M0070.html?dwvar_320164011M0070_color=050330628212#start=1

### Test Feature: 
**Product Image Zoom**
- When hovering over an image, a zoom window appears to the right of the image with a magnified view of the image
- When clicking on an image, a zoom popup box appears in the center of page

### Description:

https://www.belk.com/ is online shopping website for the department store, Belk. I discovered this site and its noticable bugs while randomly shopping online one day and thought it would make a good subject for a test plan. This test plan applies to pretty much any product page on the belk.com website, but I used a specific product to make testing easier to follow. This test covers the functionality and usability of the Product Image Zoom feature when viewing on desktop browser as well some regression and integration tests with the existing Categories Menu feature. It does not cover testing on a mobile environment. 

### Preconditions:
- Desktop web browser, live internet connection

### Test Environment Used: 
- OS: Windows 10 Home Edition, Version 21H1, Build: 19043.2006

- Chrome Browser: Version 105.0.5195.127 (Official Build) (64-bit)

## Test cases:

#### TC1: Zoom-On-Hover

Test type: functionality test

##### Steps:
 1. Go to subject link
 2. Hover over the largest product image with cursor
 3. Hover off of the image

##### Expected Result:
Hovering over a product image reveals a zoom window that appears to the right. The zoom window shows a magnified view of the image that tracks along with the cursor. The zoom window disappears once the cursor hovers off the image.

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

#### TC6: Zoom-Click-Scroll

Test type: functionality test

##### Steps:
1. Go to subject link
2. Click on the largest product image with cursor to reveal the zoom pop-up
3. Hover over the pop-up and scroll up and down
4. Hover outside of the pop-up and scroll up and down the page

##### Expected Result:
Scrolling only moves the pop-up since it is the foreground object. Scrolling should be disabled for the rest of the page.

##### Actual Result:
Same as expected.

[zoom-click-scroll.webm](https://user-images.githubusercontent.com/54592360/194750186-39246b2d-c3be-4d2b-9fc7-538b9bc5f1fc.webm)

---

#### TC7: Zoom-Hover-Scroll-Bug

Test type: functionality test

##### Steps:
1. Go to subject link
2. Hover over largest product image with cursor to reveal the zoom window to the right
3. Scroll up and down the page while still hovering over the image

##### Expected Result:
The zoom window should match the portion of the image as it scrolls underneath the sticky nagivation bar 

##### Actual Result:
**Bug:** The zoom window presists fully and blocks contents of the navigation bar when scrolling down the page with the cursor over the image.

[zoom-hover-scroll-bug.webm](https://user-images.githubusercontent.com/54592360/194750736-18f65669-fc27-4307-9dd2-5445c80b899c.webm)

---

#### TC8: categories-menu-open

Test type: regression test

##### Steps:
1. Go to subject link
2. Hover over an item in the categories menu "Women, Men, Kids, Shoes..."

##### Expected Result:
The categories menu opens to reveal the subcategories based on whatever menu item is selected.

##### Actual Result:
Same as expected.

[categories-menu-open.webm](https://user-images.githubusercontent.com/54592360/194751165-e208a88b-9f83-4f90-8fc7-f4004b5639c1.webm)

---

#### TC9: categories-menu-close

Test type: regression test

##### Steps:
1. Go to subject link
2. Hover over an item in the categories menu to reveal the subcategories menu
3. Hover off the menu
4. Click off the menu

##### Expected Result:
The subcategories menu should disappear once the cursor is no longer hovering over any categories or subcategories

##### Actual Result:
**BUG?** Unless this is by design, the menu remains open even though the cursor moved off. It only closes when the user clicks outside the menu. Hard to say if this is a bug or not without knowing the requirement specs for this feature. Since the menu opens with hover-on, it is more intuitive if it also closes with hover-off. For reference, see https://www.homedepot.com/. 

[categories-menu-close.webm](https://user-images.githubusercontent.com/54592360/194751914-db43adb3-4706-44d9-bf7e-b3f01f3ccc81.webm)

---

#### TC10: zoom-categories-bug

Test type: integration test (b/w Zoom Feature & Categories Menu), exploratory test

##### Steps:
1. Go to subject link
2. Set browser zoom to 75%
4. Hover over an item in the categories menu to reveal the subcategories menu
5. Hover over the product image to reveal the zoom window
6. Scroll up and down the page

##### Expected Result:
The zoom window should not appear if the categories menu is open

##### Actual Result:
**BUG** The zoom window appears and sit on top of the opened categories menu, blocking some of the subcategories from being in view

[zoom-categories-bug.webm](https://user-images.githubusercontent.com/54592360/194752500-5ed7cde2-71ec-4734-aaee-92b8486a74bd.webm)

---

