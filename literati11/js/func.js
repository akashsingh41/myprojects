$(document).ready(function(){
	$("#slider ul").jcarousel({
		scroll: 1,
		wrap: 'both',
		initCallback: mycarousel_initCallback,
		itemVisibleInCallback: mycarousel_itemVisibleInCallback,
		buttonNextHTML: null,
		buttonPrevHTML: null
    });
    
    if ($.browser.msie && $.browser.version.substr(0,1)<7) {
    	DD_belatedPNG.fix('#navigation, #navigation ul, #slider-frame, .quote , .quote .inner, .box .t, .box .b, .box .cnt, .btn, .btn span');
    };
});
function mycarousel_initCallback(carousel) {
	
	$(".slider-controls a").click(function(){
    	var x = parseInt($(this).text());
    	carousel.scroll(x);
    	return false;
    });
};
function mycarousel_itemVisibleInCallback(carousel, li, pos, state) {
	$(".slider-controls a").removeClass('active');
	$(".slider-controls a").eq(pos-1).addClass('active');
};
