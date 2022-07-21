/*
 * Weblogina: Technology Related News
 *
 * CC BY 3.0. 2011 Weblogina.com
 * Coded and built with love by Sallar Kaboli at Phoenix Alternative
 * Twitter: @sallar | Website: sallar.me
 */

$(document).ready(function () {
    
    /**
     * Le Prettify
     */
    if( $('pre').size() > 0 )
    {
        $('pre').addClass('prettyprint linenums');
        prettyPrint();
    }
    /**
     * Le Media
     */
    
    
    $('.radio audio').wrap  ('<div class="middle"></div>').parents('.middle')
                     .before('<div class="left"></div>')
                     .after ('<div class="right"></div>');
    
    $('.radio').each(function()
    {
        var progress = $(this).hasClass('has-progress'),
            width    = progress ? 300 : 65,
            feature  = progress ? ['playpause','current', 'progress', 'duration'] : ['playpause','current'];
            
            
        $('audio', this).mediaelementplayer({
            audioWidth: width,
            pluginPath: '/static/media/',
            features: feature,
            iPadUseNativeControls: true,
            iPhoneUseNativeControls: true, 
            AndroidUseNativeControls: true
        }).parents('.radio').show();
    });
    
    
    $('video').mediaelementplayer({
        pluginPath: '/static/media/',
        defaultVideoWidth: 640,
        defaultVideoHeight: 400,
        iPadUseNativeControls: true,
        iPhoneUseNativeControls: true, 
        AndroidUseNativeControls: true
    }).parents('.video-post').show();
    
    /**
     * Le Hover Card
     */
    
    $(".posts article .info .author").each(function(){
        var item   = $(this),
            author = item.data('author');

        item.hovercard({
            openOnLeft: true,
            detailsHTML: authors[author].html,
            cardImgSrc: authors[author].img
        });
    });
    
    /**
     * Le Share
     */
    
    var shareTimeout;
    
    $('.shareBox').sharrre({
        share: {
            googlePlus: true,
            facebook: true,
            twitter: true,
            linkedin: true
        },
        buttons: {
            googlePlus: {size: 'tall'},
            facebook: {layout: 'box_count'},
            twitter: {count: 'vertical', via: 'weblogina'},
            linkedin: {counter: 'top'}
        },
        hover: function(api, options){
            $(api.element).find('.buttons').show();
            window.clearTimeout(shareTimeout);
        },
        hide: function(api, options){
            shareTimeout = window.setTimeout(function(){
                $(api.element).find('.buttons').fadeOut();
            }, 1000);
        },
        enableTracking: true
    });
    
    /**
     * Le Topbar
     */
    
//    var $window = $(window),
//        top     = $('.topbar .nav'),
//        mini    = $('.miniNav', top),
//        nav     = $('nav .mainNav');
//    
//    top.append(nav.clone().hide());
//    top = $('.mainNav', top);
//    
//    $window.scroll(function() {
//        var windowTop = $window.scrollTop(),
//            elTop = nav.offset().top;
//        
//        if( windowTop > elTop ){
//            top.show();
//            mini.hide();
//        }
//        else{
//            top.hide();
//            mini.show();
//        }
//    });
//    
    
    /**
     * Le Slider
     */
    
    var index = 0,
        slider = $(".slider"),
	    images = $(".big figure", slider),
	    thumbs = $(".thumbs .small", slider),
	    imgHeight = $(thumbs).height() + 2,
	    sliding,
	    waitTime = 8000;
	    
	$(thumbs).slice(0,3).clone().appendTo(".thumbs", slider);
	
	for (i=0; i<thumbs.length; i++)
	{
		$(thumbs[i]).addClass("thumb-"+i);
		$(images[i]).addClass("image-"+i);
	}
	
	$(".next", slider).click(sift);
	show(index);
	window.clearInterval(sliding);
	sliding = window.setInterval(sift, waitTime);
	
	slider.bind({
	   mouseenter: function(){
	       $(".next", slider).fadeIn();
	       window.clearInterval(sliding);
	   },
	   mouseleave: function(){
	       $(".next", slider).fadeOut();
	       sliding = window.setInterval(sift, waitTime);
	   }
	});
	
	function sift()
	{
		if (index<(thumbs.length-1)){index+=1 ; }
		else {index=0}
		show (index);
	}
	
	function show(num)
	{
		$(images).fadeOut(400);
		$(".image-"+num).stop().fadeIn(400);
		var scrollPos = (num+1)*imgHeight;
		$(".thumbs", slider).stop().animate({scrollTop: scrollPos}, 400);
	}
	
	/**
     * Le Tabs
     */
     
    $(".sidebar .box .menu a").click(function(e){
        var self      = $(this),
            li        = self.parents('li'),
            parent    = self.parents('.box'),
            boxHeight = parent.height(),
            id        = self.attr('href').replace('#', ''),
            title     = $('h4 span', parent);
        
        if( !li.hasClass('selected') && parent.find(':animated').length == 0 )
        {
            $('.slide.active', parent).fadeOut(200, function()
            {
                var slide     = $('.slide.' + id, parent),
                    oldHeight = boxHeight - $(this).height(),
                    newHeight;

                slide.fadeIn(200).addClass('active');
                
                /*parent.animate({
                    height: slide.height() + oldHeight
                }, 300);*/
                
                $(this).removeClass('active');
                
            });
            
            $('.menu li', parent).removeClass('selected');
            self.parents('li').addClass('selected');
            
            if( self.data('title') ){
                title.html(self.data('title'));
            }
        }
        
        
        e.preventDefault();
    });
     
    /**
     * Le Other
     */
    
    $(".mini-slider figure").hover(function(){
        $("figcaption", this).fadeIn(200);
    }, function(){
        $("figcaption", this).fadeOut(200);
    });
    
    $(".topbar .search input").bind('focus', function(){
        $(this).animate({width: '210px'}, 100);
    }).bind('blur', function(){
        $(this).animate({width: '150px'}, 100);
    });
    
    $(".topbar .search").submit(function(e)
    {
        e.preventDefault();
        var val = $('input', this).val();
        window.location.href = "/search/" + val;
    });
    
});