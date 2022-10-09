## Test Plan
### Subject: https://www.belk.com/p/madison-slim-fit-dynamic-cooling-stretch-dress-shirt/320164011M0070.html?dwvar_320164011M0070_color=050330628212#start=1

https://www.belk.com/ is online shopping website for the department store, Belk. I discovered this site while randomly shopping online one day and thought it would make a good subject for a test plan since it had noticable bugs. This test plan applies to pretty much any product page on the site, but I used a specific example to make testing easier to follow. This test covers the functionality and usability of the Product Image Zoom when viewing on desktop browser. It does not cover testing on a mobile environment. 

### Test Feature: Product Image Zoom
- When hovering over an image, a zoom window appears to the right of the image with a magnified view of the image: ![zoom-on-hover](https://user-images.githubusercontent.com/54592360/194744557-5ef71775-0304-47f2-b794-3ecacbb6eeff.gif)
- When clicking on an image, a zoom popup box appears in the center of page: ![zoom-on-click](https://user-images.githubusercontent.com/54592360/194744586-873dd11c-29b6-423e-815c-7ebb1e8aabc3.gif)

### Preconditions:
Desktop web browser, live internet connection

### Test Environment Used: 
OS: Windows 10 Home Edition, Version 21H1, Build: 19043.2006

Chrome Browser: Version 105.0.5195.127 (Official Build) (64-bit)

--- 

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
The zoom window flashes on and off when the cursor is off the image

https://user-images.githubusercontent.com/54592360/194747709-b41d4e61-fdab-46b3-a485-165f4ca05f12.mp4

--- 

#### 3. Bug: Flashing zoom window when hover on and off of photo (see video)



