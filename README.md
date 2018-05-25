# osu!LiveDisplay

This project aims to offer a cool-looking live display for streamers that is easy to use and integrate.

## How to use it?
### Step 1: Locate your osu folder.
This is important, as osu!LiveDisplay reads your osu.db to gather stats about maps, find their beatmapsetids and all that jazz.
This allows osu!LiveDisplay to display OD,AR,Stars etc. Keep it mind, this approach is very RAM intensive, but I couldn't think of a better approach that wouldn't rely on memory reading.

![Screenshot of the settings GUI](https://raw.githubusercontent.com/JSichtig/osu-LiveDisplay/master/README/screenshot.PNG)

### Step 2: Change your settings
osu!LiveDisplay offers quite a few settings (admittedly not a lot yet) for customization.
* "Hidden on menu?" - this options allows you to completely hide the display while you're not playing a song.
* Scrollspeed - how fast the text scrolls if the title or artist is too long for complete visibility.
* Wait (in s) - the delay after and before the text scrolls.

### (Step 3: Test the display)
By selecting one of the beatmaps displayed in the itemlist, you can preview how it's gonna look without having osu! actively running.

![Screenshot of osu!LiveDisplay](https://raw.githubusercontent.com/JSichtig/osu-LiveDisplay/master/README/ScreenshotTest.PNG)

### (Step 4: Go ingame!)
Once you play a song, osu!LiveDisplay will automatically start displaying the current song you're playing!


![Screenshot of osu!LiveDisplay while ingame](https://raw.githubusercontent.com/JSichtig/osu-LiveDisplay/master/README/ScreenShotIngame.PNG)

## TODO:
* Save and load settings
* Add smooth transitions and other fancy effects
* Sync scrolling titles and artists
* Add stats display

## Dependencies:
* [osu-database-reader](https://github.com/HoLLy-HaCKeR/osu-database-reader) - used to read osu.db
