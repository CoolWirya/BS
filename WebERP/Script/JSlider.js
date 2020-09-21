(function () {

    $.fn.makeSlider =
function (element) {
    var currentPosition = 0;
    var numberOfSlides = 0;
    var slideWidth = 500;
    var speed = 6000;
    // $.fn.jSlider = function () {
    var slides = $(this).find('div.slide');
    //var slides = $(element).find('div.slide');
    numberOfSlides = slides.length;
    var slideShowInterval;
    var self = this;
    self.el = $(element);
    //Assign a timer, so it will run periodically

    slideShowInterval = setInterval(changePosition, speed);

    slides.wrapAll('<div id="' + element + '_slidesHolder"></div>')

    slides.css({ 'float': 'right' });

    //set #slidesHolder width equal to the total width of all the slides
    $('#' + element + '_slidesHolder').css('width', slideWidth * numberOfSlides);

    //$('#slideshow')
    //    .prepend('<span class="nav" id="leftNav">Move Left</span>')
    //   .append('<span class="nav" id="rightNav">Move Right</span>');

    manageNav(currentPosition);

    //tell the buttons what to do when clicked
    $('#' + element + ' .nav').bind('click', function () {
        //determine new position
        currentPosition = ($(this).attr('id') == 'rightNav')
        ? currentPosition + 1 : currentPosition - 1;
        //hide/show controls
        manageNav(currentPosition);
        clearInterval(slideShowInterval);
        slideShowInterval = setInterval(changePosition, speed);
        moveSlide();
    });

    function manageNav(position) {
        //hide left arrow if position is first slide
        if (position == 0) { $('#' + element + ' #leftNav').hide() }
        else { $('#' + element + ' #leftNav').show() }
        //hide right arrow is slide position is last slide
        if (position == numberOfSlides - 1) { $('#' + element + ' #rightNav').hide() }
        else { $('#' + element + ' #rightNav').show() }
    }


    //changePosition: this is called when the slide is moved by the timer and NOT when the next or previous buttons are clicked
    function changePosition() {
        if (currentPosition == numberOfSlides - 1) {
            currentPosition = 0;
            manageNav(currentPosition);
        } else {
            currentPosition++;
            manageNav(currentPosition);
        }
        moveSlide();
    }


    //moveSlide: this function moves the slide
    function moveSlide() {
        $('#' + element + '_slidesHolder').animate({ 'marginRight': slideWidth * (-currentPosition) });
    }
    //};
}
})(jQuery);


