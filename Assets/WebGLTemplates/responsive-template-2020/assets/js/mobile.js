/* The following scripts detect a mobile device and put the game in mobile mode:
    - Instead of loading the game, load the demo video
    - Replaces game tips with load with prompt to play the game on a laptop/desktop
*/

var game = document.getElementById("game");
var demo = document.getElementById("demo");
var fullscreenButton = document.getElementById("fullscreen-button");
var changeableTip = document.getElementById("changeable-tip");
var changeableHeading = document.getElementById("changeable-heading");
var activityTips = document.getElementsByClassName("activity-tip");

isMobile = false;
if (/Android|webOS|iPhone|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
    isMobile = true;
}

isIPad = false;
if (/iPad/i.test(navigator.userAgent)) {
    isIPad = true;
}

if (isMobile || isIPad) {
    game.remove();
    demo.style.display = "block";
    fullscreenButton.style.display = "none";
    changeableTip.innerHTML = "<i class='fa fa-exclamation-triangle' aria-hidden='true'></i> This activity is not optimized for phones and tablets. Open on a desktop computer for the full experience or read more about this work below.";
    changeableHeading.innerHTML = "Let's play!";
    for (i = 0; i < 4; i++) {
        activityTips[3 - i].remove();
    }
}