function updateForm_(){
	if($j('#form_')){
		var params = $j('#form_').serialize();
	}
	$j('#contactform').load('/modules/mailform_2_0/index.php?name=Contact%20Us%20Form&ampid=contactform', params, function() {
		$j("label").inFieldLabels();	
	});
	return false;
}

var $j = jQuery.noConflict();

$j(document).ready(function() { 
	if($j('#form_')){
		var params = $j('#form_').serialize();
	}
	$j('#contactform').load('/modules/mailform_2_0/index.php?name=Contact%20Us%20Form&ampid=contactform', params, function() {
		$j("label").inFieldLabels();
	});

  // IE6 doesn't handle the fade effect very well - so we'll stick with
  // the default non JavaScript version if that is the user's browser.
  if ($j.browser.msie && $j.browser.version < 7) return;
  
  $j('#navigation li, #footertitle div, #recentwork div, #touch div, #more div, #subnavtop h2')
  
    // remove the 'highlight' class from the li therefore stripping 
    // the :hover rule
    .removeClass('highlight')
    
    // within the context of the li element, find the a elements
    .find('a')
    
    // create our new span.hover and loop through anchor:
    .append('<span class="hover" />').each(function () {
      
      // cache a copy of the span, at the same time changing the opacity
      // to zero in preparation of the page being loaded
      var $jspan = $j('> span.hover', this).css('opacity', 0);
      
      // when the user hovers in and out of the anchor
      $j(this).hover(function () {
        // on hover
        
        // stop any animations currently running, and fade to opacity: 1
        $jspan.stop().fadeTo(500, 1);
      }, function () {
        // off hover
        
        // again, stop any animations currently running, and fade out
        $jspan.stop().fadeTo(500, 0);
      });
	});

	if ($j('.slideshow').cycle != undefined) {
		$j('.slideshow').cycle({
			fx: 'scrollLeft', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
		    timeout:       3000,  // milliseconds between slide transitions (0 to disable auto advance) 
		    continuous:    0,     // true to start next transition immediately after current one completes 
		    speed:         1000  // speed of the transition (any valid fx speed value)
		});
	}

});
 
