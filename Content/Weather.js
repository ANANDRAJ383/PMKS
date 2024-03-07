AUI().ready(function () { var a = document.getElementById("distList").value; if (a == null || a == "") { $("#testWeather").weatherfeed(["1"], { woeid: true, unit: "c", image: true, city: false, country: false, highlow: true, wind: true, humidity: true, visibility: false, sunrise: false, sunset: false, linktarget: "_blank", forecast: false, link: true }) } else { $("#testWeather").weatherfeed([a], { woeid: true, unit: "c", image: true, city: false, country: false, highlow: true, wind: true, humidity: true, visibility: false, sunrise: false, sunset: false, linktarget: "_blank", forecast: false, link: true }) } $("#distList").change(function (c) { var f = document.getElementById("distList").value; var b = document.getElementById("testWeather"); b.innerHTML = ""; c.preventDefault(); if (f != "") { $("#testWeather").weatherfeed([f], { woeid: true, unit: "c", image: true, city: false, country: false, highlow: true, wind: true, humidity: true, visibility: false, sunrise: false, sunset: false, linktarget: "_blank", forecast: false, link: true }) } else { $("#testWeather").weatherfeed(["2295383"], { woeid: true, unit: "c", image: true, city: false, country: false, highlow: true, wind: true, humidity: true, visibility: false, sunrise: false, sunset: false, linktarget: "_blank", forecast: false, link: true }) } }) }); (function (a) { a.fn.weatherfeed = function (e, c, b) { c = a.extend({ unit: "c", image: !0, country: !1, highlow: !0, wind: !0, humidity: !1, visibility: !1, sunrise: !1, sunset: !1, forecast: !1, link: !0, showerror: !0, linktarget: "_self", woeid: !1 }, c); var f = "odd"; return this.each(function (s, p) { var i = a(p); i.hasClass("weatherFeed") || i.addClass("weatherFeed"); if (!a.isArray(e)) { return !1 } var g = e.length; 10 < g && (g = 10); var j = ""; for (s = 0; s < g; s++) { "" != j && (j += ","), j += "'" + e[s] + "'" } now = new Date; g = "http://query.yahooapis.com/v1/public/yql?q=" + encodeURIComponent("select * from weather.forecast where " + (c.woeid ? "woeid" : "location") + " in (" + j + ") and u='" + c.unit + "'") + "&rnd=" + now.getFullYear() + now.getMonth() + now.getDay() + now.getHours() + "&format=json&callback=?"; a.ajax({ type: "GET", url: g, dataType: "json", success: function (k) { if (k.query) { if (0 < k.query.results.channel.length) { for (var m = k.query.results.channel.length, l = 0; l < m; l++) { h(p, k.query.results.channel[l], c) } } else { h(p, k.query.results.channel, c) } a.isFunction(b) && b.call(this, i) } else { c.showerror && i.html("<p>Weather information unavailable</p>") } }, error: function () { c.showerror && i.html("<p>Weather request failed</p>") } }); var h = function (q, u, t) { q = a(q); if ("Yahoo! Weather Error" != u.description) { var l = u.wind.direction; 348.75 <= l && 360 >= l && (l = "N"); 0 <= l && 11.25 > l && (l = "N"); 11.25 <= l && 33.75 > l && (l = "NNE"); 33.75 <= l && 56.25 > l && (l = "NE"); 56.25 <= l && 78.75 > l && (l = "ENE"); 78.75 <= l && 101.25 > l && (l = "E"); 101.25 <= l && 123.75 > l && (l = "ESE"); 123.75 <= l && 146.25 > l && (l = "SE"); 146.25 <= l && 168.75 > l && (l = "SSE"); 168.75 <= l && 191.25 > l && (l = "S"); 191.25 <= l && 213.75 > l && (l = "SSW"); 213.75 <= l && 236.25 > l && (l = "SW"); 236.25 <= l && 258.75 > l && (l = "WSW"); 258.75 <= l && 281.25 > l && (l = "W"); 281.25 <= l && 303.75 > l && (l = "WNW"); 303.75 <= l && 326.25 > l && (l = "NW"); 326.25 <= l && 348.75 > l && (l = "NNW"); var m = u.item.forecast[0]; wpd = u.item.pubDate; n = wpd.indexOf(":"); tpb = o(wpd.substr(n - 2, 8)); tsr = o(u.astronomy.sunrise); tss = o(u.astronomy.sunset); daynight = tpb > tsr && tpb < tss ? "day" : "night"; var k = '<div class="weatherItem ' + f + " " + daynight + '"'; t.image && (k += ' style="background-image: url(http://l.yimg.com/a/i/us/nws/weather/gr/' + u.item.condition.code + daynight.substring(0, 1) + '.png); background-repeat: no-repeat;"'); k = k + ">" + ('<div class="weatherCity">' + u.location.city + "</div>"); t.country && (k += '<div class="weatherCountry">' + u.location.country + "</div>"); k += '<div class="weatherTemp">' + u.item.condition.temp + "&deg;</div>"; k += '<div class="weatherDesc">' + u.item.condition.text + "</div>"; t.highlow && (k += '<div class="weatherRange">High: ' + m.high + "&deg; Low: " + m.low + "&deg;</div>"); t.wind && (k += '<div class="weatherWind">Wind: ' + l + " " + u.wind.speed + u.units.speed + "</div>"); t.humidity && (k += '<div class="weatherHumidity">Humidity: ' + u.atmosphere.humidity + "</div>"); t.visibility && (k += '<div class="weatherVisibility">Visibility: ' + u.atmosphere.visibility + "</div>"); t.sunrise && (k += '<div class="weatherSunrise">Sunrise: ' + u.astronomy.sunrise + "</div>"); t.sunset && (k += '<div class="weatherSunset">Sunset: ' + u.astronomy.sunset + "</div>"); if (t.forecast) { k += '<div class="weatherForecast">'; l = u.item.forecast; for (m = 0; m < l.length; m++) { k += '<div class="weatherForecastItem" style="background-image: url(http://l.yimg.com/a/i/us/nws/weather/gr/' + l[m].code + 's.png); background-repeat: no-repeat;">', k += '<div class="weatherForecastDay">' + l[m].day + "</div>", k += '<div class="weatherForecastDate">' + l[m].date + "</div>", k += '<div class="weatherForecastText">' + l[m].text + "</div>", k += '<div class="weatherForecastRange">High: ' + l[m].high + " Low: " + l[m].low + "</div>", k += "</div>" } k += "</div>" } t.link && (k += '<div class="weatherLink"><a href="' + u.link + '" target="' + t.linktarget + '" title="Read full forecast">Full forecast</a></div>') } else { k = '<div class="weatherItem ' + f + '">', k += '<div class="weatherError">City not found</div>' } k += "</div>"; f = "odd" == f ? "even" : "odd"; q.append(k) }, o = function (k) { d = new Date; return r = new Date(d.toDateString() + " " + k) } }) } })(jQuery);
<script type="text/javascript">
	// <![CDATA[
		var Liferay = {
			Browser: {
				acceptsGzip: function() {
					return true;
				},
				getMajorVersion: function() {
					return 62.0;
				},
				getRevision: function() {
					return "537.36";
				},
				getVersion: function() {
					return "62.0.3198.0";
				},
				isAir: function() {
					return false;
				},
				isChrome: function() {
					return true;
				},
				isFirefox: function() {
					return false;
				},
				isGecko: function() {
					return true;
				},
				isIe: function() {
					return false;
				},
				isIphone: function() {
					return false;
				},
				isLinux: function() {
					return false;
				},
				isMac: function() {
					return false;
				},
				isMobile: function() {
					return false;
				},
				isMozilla: function() {
					return false;
				},
				isOpera: function() {
					return false;
				},
				isRtf: function() {
					return true;
				},
				isSafari: function() {
					return true;
				},
				isSun: function() {
					return false;
				},
				isWap: function() {
					return false;
				},
				isWapXhtml: function() {
					return false;
				},
				isWebKit: function() {
					return true;
				},
				isWindows: function() {
					return true;
				},
				isWml: function() {
					return false;
				}
			},

			Data: {
				isCustomizationView: function() {
					return false;
				},

				notices: [
					null

					

					
				]
			},

			ThemeDisplay: {
				getCompanyId: function() {
					return "10153";
				},
				getCompanyGroupId: function() {
					return "10191";
				},
				getUserId: function() {
					return "10157";
				},

				

				getDoAsUserIdEncoded: function() {
					return "";
				},
				getPlid: function() {
					return "13098";
				},

				
					getLayoutId: function() {
						return "39";
					},
					getLayoutURL: function() {
						return "http://www.jharkhand.gov.in/agri";
					},
					isPrivateLayout: function() {
						return "false";
					},
					getParentLayoutId: function() {
						return "166";
					},
				

				getScopeGroupId: function() {
					return "10179";
				},
				getScopeGroupIdOrLiveGroupId: function() {
					return "10179";
				},
				getParentGroupId: function() {
					return "10179";
				},
				isImpersonated: function() {
					return false;
				},
				isSignedIn: function() {
					return false;
				},
				getDefaultLanguageId: function() {
					return "en_US";
				},
				getLanguageId: function() {
					return "en_US";
				},
				isAddSessionIdToURL: function() {
					return false;
				},
				isFreeformLayout: function() {
					return false;
				},
				isStateExclusive: function() {
					return false;
				},
				isStateMaximized: function() {
					return false;
				},
				isStatePopUp: function() {
					return false;
				},
				getPathContext: function() {
					return "";
				},
				getPathImage: function() {
					return "/image";
				},
				getPathJavaScript: function() {
					return "/html/js";
				},
				getPathMain: function() {
					return "/c";
				},
				getPathThemeImages: function() {
					return "/JhssdgResponsive-theme/images";
				},
				getPathThemeRoot: function() {
					return "/JhssdgResponsive-theme/";
				},
				getURLHome: function() {
					return "http://www.jharkhand.gov.in/web/guest";
				},
				getSessionId: function() {
					return "13B9BAED568C58586DC47FDEA1CAF5F5.node1";
				},
				getPortletSetupShowBordersDefault: function() {
					return true;
				}
			},

			PropsValues: {
				NTLM_AUTH_ENABLED: false
			}
		};

		var themeDisplay = Liferay.ThemeDisplay;

		

		Liferay.AUI = {
			getBaseURL: function() {
				return 'http://www.jharkhand.gov.in/html/js/aui/';
			},
			getCombine: function() {
				return true;
			},
			getComboPath: function() {
				return '/combo/?browserId=other&minifierType=&languageId=en_US&b=6100&t=1422843725000&p=/html/js&';
			},
			getFilter: function() {
				
					
						return {
							replaceStr: function(match, fragment, string) {
								return fragment + 'm=' + (match.split('/html/js')[1] || '');
							},
							searchExp: '(\\?|&)/([^&]+)'
						};
					
					
					
				
			},
			getJavaScriptRootPath: function() {
				return '/html/js';
			},
			getLangPath: function () {
				return 'aui_lang.jsp?browserId=other&themeId=JhssdgResponsivedepart_WAR_JhssdgResponsivetheme&colorSchemeId=01&minifierType=js&languageId=en_US&b=6100&t=1422843725000';
			},
			getRootPath: function() {
				return '/html/js/aui/';
			}
		};

		window.YUI_config = {
			base: Liferay.AUI.getBaseURL(),
			comboBase: Liferay.AUI.getComboPath(),
			fetchCSS: true,
			filter: Liferay.AUI.getFilter(),
			root: Liferay.AUI.getRootPath(),
			useBrowserConsole: false
		};

		

		Liferay.currentURL = '\x2fagri';
		Liferay.currentURLEncoded = '%2Fagri';
	// ]]>
</script>


	
		
			
				<script src="/html/js/barebone.jsp?browserId=other&amp;themeId=JhssdgResponsivedepart_WAR_JhssdgResponsivetheme&amp;colorSchemeId=01&amp;minifierType=js&amp;minifierBundleId=javascript.barebone.files&amp;languageId=en_US&amp;b=6100&amp;t=1422843725000" type="text/javascript"></script>
			
			
		
	
	




<script type="text/javascript">
	// <![CDATA[
		

			

			
				Liferay.Portlet.list = ['56_INSTANCE_gsd16roCbT9j','56_INSTANCE_F347PkGzJesq','56_INSTANCE_hXDLQ9OZzAmu','sliderportlet_WAR_imgesliderportlet_INSTANCE_d9ZBjkhFYBb0','56_INSTANCE_CsF4uyFoy4cx','118_INSTANCE_4bPBJtrrnTzs','56_INSTANCE_Oklo8pt6eNMw','PhotoGallery_WAR_PhotoGalleryportlet','56_INSTANCE_J34D5tsC5Pjo','56_INSTANCE_yK23vlnWeXIr','56_INSTANCE_GtN3Gufay8Zv','56_INSTANCE_PXHY1xPTgL8n'];
			
		

		

		
	// ]]>
</script>






	<script type="text/javascript">
		var _gaq = _gaq || [];

		_gaq.push(['_setAccount', 'UA-47613539-1']);
		_gaq.push(['_trackPageview']);

		(function() {
			var ga = document.createElement('script');

			ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';

			ga.setAttribute('async', 'true');

			document.documentElement.firstChild.appendChild(ga);
		})();
	</script>

