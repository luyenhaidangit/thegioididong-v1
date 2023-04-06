<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Luu Minh Hoang - TestRoom1</title>
    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="css/simple-sidebar.css" rel="stylesheet">
  </head>
  <body>
    <div class="d-flex" id="wrapper">
      <!-- Sidebar -->
      <div class="bg-light border-right" id="sidebar-wrapper">
        <!-- layout.js/sidebar -->
      </div>
      <!-- /#sidebar-wrapper -->
      <!-- Page Content -->
      <div id="page-content-wrapper">
        <!-- Above is layout.js/content -->
        <!-- Following is content -->
        <div class="container-fluid">
          <?php echo $_SERVER['HTTP_USER_AGENT']; ?>
          <h1 class="mt-4">FRICK</h1>
          <form action="php/register.php" method="POST">
            <table border='1'>
              <tr>
                <td>Name: </td>
                <td><input type="text" name="userName"></td>
              </tr>
              <tr>
                <td>Password: </td>
                <td><input type="password" name="userPw"></td>
              </tr>
              <tr>
                <td>Age: </td>
                <td><input type="text" name="userAge"></td>
              </tr>
              <tr>
                <td>Gender: </td>
                <td>
                  <input type="radio" name="userGender" value="0"> Male
                  <input type="radio" name="userGender" value="1"> Female
                </td>
              </tr>
              <tr>
                <td>Role: </td>
                <td>
                  <select name="userRole">
                    <option hidden></option>
                    <option value="admin">Boss</option>
                    <option value="user">Unboss</option>
                  </select>
                </td>
              </tr>
              <tr>
                <td colspan="2" align="center">
                  <input type="submit" value="Submit">
                </td>
              </tr>
            </table>
          </form>
        </div>
        <!-- /#page-content-wrapper -->
      </div>
      <!-- /#wrapper -->
      <!-- Bootstrap core JavaScript -->
      <script src="vendor/jquery/jquery.min.js"></script>
      <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
      <!-- Startup -->
      <script src="js/layout.js"></script>
      <script>
      getLayout();
      </script>
      <!-- Menu Toggle Script -->
      <script>
      $("#menu-toggle").click(function(e) {
      e.preventDefault();
      $("#wrapper").toggleClass("toggled");
      });
      </script>
    </body>
  </html>