const slidePage = document.querySelector(".slide-page-art");
const nextBtnFirst = document.querySelector(".firstNext");
const prevBtnSec = document.querySelector(".prev-1");
const nextBtnSec = document.querySelector(".next-1");
const prevBtnThird = document.querySelector(".prev-2");
const nextBtnThird = document.querySelector(".next-2");
const prevBtnFourth = document.querySelector(".prev-3");
const submitBtn = document.querySelector(".submit");
const progressText = document.querySelectorAll(".step-art p");
const progressCheck = document.querySelectorAll(".step-art .check");
const bullet = document.querySelectorAll(".step-art .bullet-art");


// nextBtnFirst.addEventListener("onClick", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "-25%";
//     bullet[current - 1].classList.add("active");
//     progressCheck[current - 1].classList.add("active");
//     progressText[current - 1].classList.add("active");
//     current += 1;
// });
// nextBtnSec.addEventListener("click", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "-50%";
//     bullet[current - 1].classList.add("active");
//     progressCheck[current - 1].classList.add("active");
//     progressText[current - 1].classList.add("active");
//     current += 1;
// });
// nextBtnThird.addEventListener("click", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "-75%";
//     bullet[current - 1].classList.add("active");
//     progressCheck[current - 1].classList.add("active");
//     progressText[current - 1].classList.add("active");
//     current += 1;
// });
// submitBtn.addEventListener("click", function () {
//     bullet[current - 1].classList.add("active");
//     progressCheck[current - 1].classList.add("active");
//     progressText[current - 1].classList.add("active");
//     current += 1;
//     setTimeout(function () {
//         alert("Your Form Successfully Signed up");
//         window.location.reload();
//     }, 800);
// });

// prevBtnSec.addEventListener("click", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "0%";
//     bullet[current - 2].classList.remove("active");
//     progressCheck[current - 2].classList.remove("active");
//     progressText[current - 2].classList.remove("active");
//     current -= 1;
// });
// prevBtnThird.addEventListener("click", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "-25%";
//     bullet[current - 2].classList.remove("active");
//     progressCheck[current - 2].classList.remove("active");
//     progressText[current - 2].classList.remove("active");
//     current -= 1;
// });
// prevBtnFourth.addEventListener("click", function (event) {
//     event.preventDefault();
//     slidePage.style.marginLeft = "-50%";
//     bullet[current - 2].classList.remove("active");
//     progressCheck[current - 2].classList.remove("active");
//     progressText[current - 2].classList.remove("active");
//     current -= 1;
// });