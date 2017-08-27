<p align="center">
    <img src="https://i2.wp.com/midiainteressante.com/wp-content/uploads/2017/05/marte-notice-how-the-landscape-contrasts-with-the-rocky-terrain-at-the-big-sky-site-that-curiosity-crossed-in-october-800x800.jpg?resize=800%2C800" height="343" width="338" style="border-radius: 50%;">
</p>
<h2 align="center">Curiosity Mars Rover</h2>
<br/>

### Program overview
A rover has been sent to Mars to survey the terrain. Mars’s surface has been divided into zones and each zone have been very carefully surveyed ahead of time and are deemed safe for exploration. Due to the transmission delay in communicating with the rover on Mars, you are only able to send the rover a list of commands.

This program will upload the commands and the rover will execute them.

### How it works
The application will ask you to upload a text file that contains instructions for the rover to prosess.

The format of the text file is as follows
* Grid dimention.
* Rover location with the diretion it's faceing.
* Movement instructions.

```
8 8
1 2 E
MMLMMMRRMM
```

* When the instruction "M" is read, the rover will move forward one block in the direction it's faceing.
* When the instruction "L" is read, the rover will turn left by 90 degrees.
* When the instruction "R" is read, the rover will turn right by 90 degrees.

After the rover has executed the movement instructions has been executed, the rover will return its location.
If the rover moves out of the grid; it will return its loctation and let you know that it has enterd an area that it doesn't know.

If the rover doesn't know the movement insturction then it will skip that instruction and return the instructions that it didn't know.