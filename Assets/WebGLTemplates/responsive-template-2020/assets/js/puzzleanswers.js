/* The following scripts reveal individual answers in the answer section at the bottom of the game page */

var puzzleAnswers = document.getElementsByClassName("puzzle-answer");

for (i = 0; i < puzzleAnswers.length; i++) {
	puzzleAnswers[i].addEventListener("click", function () {
		this.innerHTML = this.getAttribute("name");
		this.style.textTransform = "uppercase";
		this.classList.remove("puzzle-answer"); // Remove styles so it no longer resembles a clickable item (i.e. color and hover effects)
	});
}
