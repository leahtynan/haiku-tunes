/* The following scripts copy my email address to the clipboard when the mail icon is clicked */

var emailIcon = document.getElementById("email");
var emailCopyMessage = document.getElementById("email-copy-message");
console.log(emailCopyMessage);
emailCopyMessage.style.display = "none";

emailIcon.addEventListener("mouseenter", function (event) {
	console.log("enter");
	emailCopyMessage.style.display = "block";
}, false);

emailIcon.addEventListener("click", function (event) {
	console.log("click");
	copyToClipboard("brunetto@alum.mit.edu");
	emailCopyMessage.innerHTML = "Copied the e-mail address!";
	setTimeout(function () {
		emailCopyMessage.style.display = "none";
	}, 2000);
}, false);

emailIcon.addEventListener("mouseleave", function (event) {
	console.log("exit");
	emailCopyMessage.style.display = "none";
	emailCopyMessage.innerHTML = "Click to copy e-mail address.";
}, false);

function copyToClipboard(text) {
	const el = document.createElement('textarea');
	el.value = text;
	el.setAttribute('readonly', '');
	el.style.position = 'absolute';
	el.style.left = '-9999px';
	document.body.appendChild(el);
	el.select();
	document.execCommand('copy');
	document.body.removeChild(el);
};
