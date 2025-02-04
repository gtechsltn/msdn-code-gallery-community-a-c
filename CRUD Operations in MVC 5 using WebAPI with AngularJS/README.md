# CRUD Operations in MVC 5 using WebAPI with AngularJS
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2013
- WebAPI
- ASP.NET MVC 5
- AngularJS
## Topics
- AngularJS
- MVC 5 with WebAPI
- MVC 5 with ANgularJS
- crud operations in mvc5
- crud operation in webapi
- crud in mvc 5
- crud in mvc 5 with angularjs and web api
## Updated
- 06/27/2014
## Description

<h1>Introduction</h1>
<p>In this article I am going to explain how to perform CRUD operation in MVC 5 using WebAPI with AngularJS.</p>
<h1><span>Building the Sample</span></h1>
<ul>
<li>Start Visual Studio 2013 </li><li>Create a new Project </li><li>Select Web Template and select ASP.NET Web Application </li><li>Provide the name and location of website </li><li>Click &quot;Next&quot; </li><li>Now select MVC template and do check Web API to add folder and core references.
</li></ul>
<p>&nbsp;<img id="119239" src="119239-img1.jpg" alt="" width="763" height="536"></p>
<p>Image 1.</p>
<p>Now add a new model class in model directory.</p>
<p>&nbsp; public class Friend</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [Key]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int FriendId { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string FirstName { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string LastName { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Address { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string City { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string PostalCode { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Country { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public string Notes { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>Now add context class.</p>
<p>public class FriendsContext : DbContext</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public FriendsContext()</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : base(&quot;name=DefaultConnection&quot;)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.Configuration.ProxyCreationEnabled = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public DbSet&lt;Friend&gt; Friends { get; set; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>Now add a controller in controller directory.</p>
<p>public class FriendController : ApiController</p>
<p>&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private FriendsContext db = new FriendsContext();</p>
<p>&nbsp;</p>
<p>&nbsp;// GET api/&lt;controller&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>[HttpGet]</p>
<p>public IEnumerable&lt;Friend&gt; Get()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return db.Friends.AsEnumerable();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>// GET api/&lt;controller&gt;/5</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public Friend Get(int id)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Friend friend = db.Friends.Find(id);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (friend == null)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return friend;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>// POST api/&lt;controller&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public HttpResponseMessage Post(Friend friend)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (ModelState.IsValid)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Friends.Add(friend);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges();</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, friend);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; response.Headers.Location = new Uri(Url.Link(&quot;DefaultApi&quot;, new { id = friend.FriendId }));</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return response;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>// PUT api/&lt;controller&gt;/5</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public HttpResponseMessage Put(int id, Friend friend)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!ModelState.IsValid)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (id != friend.FriendId)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateResponse(HttpStatusCode.BadRequest);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Entry(friend).State = EntityState.Modified;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (DbUpdateConcurrencyException ex)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateResponse(HttpStatusCode.OK);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;// DELETE api/&lt;controller&gt;/5</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public HttpResponseMessage Delete(int id)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Friend friend = db.Friends.Find(id);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (friend == null)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateResponse(HttpStatusCode.NotFound);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Friends.Remove(friend);</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;{</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (DbUpdateConcurrencyException ex)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateResponse(HttpStatusCode.OK, friend);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;protected override void Dispose(bool disposing)</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Dispose();</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.Dispose(disposing);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp; }</p>
<p>Now add AngularJS using Manage Nuget Package Manager and search AngularJS.</p>
<p><img id="119241" src="119241-img2.jpg" alt="" width="898" height="596"></p>
<p>Image 2.</p>
<p>Now add a new javascript file in scripts directory and add angular functions.</p>
<p>function <strong>friendController</strong>($scope, $http) {&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; $scope.loading = true;</p>
<p>&nbsp;&nbsp;&nbsp; $scope.addMode = false;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; //Used to display the data</p>
<p>&nbsp;&nbsp;&nbsp; $http.get('/api/Friend/').success(function (data) {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.friends = data;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;&nbsp;&nbsp; })</p>
<p>&nbsp;&nbsp;&nbsp; .error(function () {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.error = &quot;An Error has occured while loading posts!&quot;;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;&nbsp;&nbsp; });</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; $scope.toggleEdit = function () {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this.friend.editMode = !this.friend.editMode;</p>
<p>&nbsp;&nbsp;&nbsp; };</p>
<p>&nbsp;&nbsp;&nbsp; $scope.toggleAdd = function () {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.addMode = !$scope.addMode;</p>
<p>&nbsp;&nbsp;&nbsp; };</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; //Used to save a record after edit</p>
<p>&nbsp;&nbsp;&nbsp; $scope.save = function () {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; alert(&quot;Edit&quot;);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = true;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var frien = this.friend;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; alert(emp);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $http.put('/api/Friend/', frien).success(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; alert(&quot;Saved Successfully!!&quot;);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; emp.editMode = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).error(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.error = &quot;An Error has occured while Saving Friend! &quot; &#43; data;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</p>
<p>&nbsp;&nbsp;&nbsp; };</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; //Used to add a new record</p>
<p>&nbsp;&nbsp;&nbsp; $scope.add = function () {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = true;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $http.post('/api/Friend/', this.newfriend).success(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; alert(&quot;Added Successfully!!&quot;);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.addMode = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.friends.push(data);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;$scope.loading = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).error(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.error = &quot;An Error has occured while Adding Friend! &quot; &#43; data;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</p>
<p>&nbsp;&nbsp;&nbsp; };</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp; //Used to edit a record</p>
<p>&nbsp;&nbsp;&nbsp; $scope.deletefriend = function () {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = true;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var friendid = this.friend.FriendId;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $http.delete('/api/Friend/' &#43; friendid).success(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; alert(&quot;Deleted Successfully!!&quot;);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $.each($scope.friends, function (i) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if ($scope.friends[i].FriendId === friendid) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.friends.splice(i, 1);</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).error(function (data) {</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.error = &quot;An Error has occured while Saving Friend! &quot; &#43; data;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $scope.loading = false;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });</p>
<p>&nbsp;&nbsp;&nbsp; };</p>
<p>&nbsp;</p>
<p>}</p>
<p>Now open _Layout.cshtml page from Shared folder and add these two lines to render AngularJS and empjs in application.</p>
<p>@Scripts.Render(&quot;~/bundles/jquery&quot;)</p>
<p>@Scripts.Render(&quot;~/bundles/bootstrap&quot;)</p>
<p>@Scripts.Render(&quot;~/bundles/angularjs&quot;)</p>
<p>@Scripts.Render(&quot;~/bundles/empjs&quot;)</p>
<p>Now let&rsquo;s work on View.</p>
<p>@{</p>
<p>&nbsp;&nbsp;&nbsp; ViewBag.Title = &quot;FriendView&quot;;</p>
<p>&nbsp;&nbsp;&nbsp; Layout = &quot;~/Views/Shared/_Layout.cshtml&quot;;</p>
<p>}</p>
<p>&nbsp;</p>
<p>&lt;h2&gt;Friends View&lt;/h2&gt;</p>
<p><style></p>
<p>    #mydiv {</p>
<p>        position: absolute;</p>
<p>        top: 0;</p>
<p>        left: 0;</p>
<p>        width: 100%;</p>
<p>        height: 100%;</p>
<p>        z-index: 1000;</p>
<p>        background-color: grey;</p>
<p>        opacity: .8;</p>
<p>    }</p>
<p> </p>
<p>    .ajax-loader {</p>
<p>        position: absolute;</p>
<p>        left: 50%;</p>
<p>        top: 50%;</p>
<p>        margin-left: -32px; /* -1 * image width / 2 */</p>
<p>        margin-top: -32px; /* -1 * image height / 2 */</p>
<p>        display: block;</p>
<p>    }</p>
<p></style></p>
<p>&lt;div <strong>data-ng-app</strong><strong> </strong><strong>data-ng-controller</strong><strong>=&quot;friendController&quot;</strong> class=&quot;container&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;strong class=&quot;error&quot;&gt;<strong>{{</strong> error <strong>
}}</strong>&lt;/strong&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;div id=&quot;mydiv&quot; data-ng-show=&quot;loading&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;img src=&quot;Images/ajax-loader.gif&quot; class=&quot;ajax-loader&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/div&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;addMode&quot;&gt;&lt;a data-ng-click=&quot;toggleAdd()&quot; href=&quot;javascript:;&quot; class=&quot;btn btn-primary&quot;&gt;Add New&lt;/a&gt;&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;form name=&quot;addFriend&quot; data-ng-show=&quot;addMode&quot; style=&quot;width:600px;margin:0px auto;&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;FirstName:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.FirstName&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;LastName:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.LastName&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;Address:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.Address&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;City:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.City&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;PostalCode:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.PostalCode&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;Country:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.Country&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;Notes:&lt;/label&gt;&lt;input type=&quot;text&quot; data-ng-model=&quot;newfriend.Notes&quot; required /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;br /&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;br /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input type=&quot;submit&quot; value=&quot;Add&quot; data-ng-click=&quot;add()&quot; data-ng-disabled=&quot;!addFriend.$valid&quot; class=&quot;btn btn-primary&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input type=&quot;button&quot; value=&quot;Cancel&quot; data-ng-click=&quot;toggleAdd()&quot; class=&quot;btn btn-primary&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;br /&gt;&lt;br /&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/form&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;table class=&quot;table table-bordered table-hover&quot; style=&quot;width:800px&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;#&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;FirstName&lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;LastName&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;Address&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;City&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;PostalCode&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;Country&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;Notes&lt;/th&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr data-ng-repeat=&quot;friend in friends&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;&lt;strong data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.FriendId
<strong>}}</strong>&lt;/strong&gt;&lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.FirstName
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.FirstName&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.LastName
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.LastName&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.Address
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.Address&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.City
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.City&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.PostalCode
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.PostalCode&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.Country
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.Country&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;<strong>{{</strong> friend.Notes
<strong>}}</strong>&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input data-ng-show=&quot;friend.editMode&quot; type=&quot;text&quot; data-ng-model=&quot;friend.Notes&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-hide=&quot;friend.editMode&quot;&gt;&lt;a data-ng-click=&quot;toggleEdit(friend)&quot; href=&quot;javascript:;&quot;&gt;Edit&lt;/a&gt; | &lt;a data-ng-click=&quot;deletefriend(friend)&quot;
 href=&quot;javascript:;&quot;&gt;Delete&lt;/a&gt;&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;p data-ng-show=&quot;friend.editMode&quot;&gt;&lt;a data-ng-click=&quot;save(friend)&quot; href=&quot;javascript:;&quot;&gt;Save&lt;/a&gt; | &lt;a data-ng-click=&quot;toggleEdit(friend)&quot; href=&quot;javascript:;&quot;&gt;Cancel&lt;/a&gt;&lt;/p&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/table&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;hr /&gt;</p>
<p>&nbsp;</p>
<p>&lt;/div&gt;</p>
<p>&nbsp;</p>
<p>Run application to see output:</p>
<p><img id="119242" src="119242-img3.jpg" alt="" width="828" height="422">&nbsp;</p>
<p>&nbsp;Image 3.</p>
<p>&nbsp;</p>
<p>Click On Add New Button:</p>
<p>&nbsp;<img id="119243" src="119243-img4.jpg" alt="" width="864" height="528"></p>
<p>&nbsp;</p>
<p>Image 4.</p>
<p>&nbsp;</p>
<p>Click on edit link:</p>
<p>&nbsp;<img id="119244" src="119244-img5.jpg" alt="" width="1310" height="373">&nbsp;</p>
<p>Image 5.</p>
<p>&nbsp;</p>
<p>For more information download attached sample.</p>
<p>&nbsp;</p>
<p><strong>Conclusion</strong></p>
<p>&nbsp;</p>
<p>In this article we have learned how to do crud operation in mvc 5 using Web API and AngularJS. If you have any question or comments put a line in c-sharcorner comments section.&nbsp;</p>
