import { createBrowserRouter, RouterProvider } from 'react-router-dom';

// Routes
import Dashboard, { dashboardLoader } from './pages/Dashboard';
import Error from "./pages/Error";

// Layouts
import Main, { mainLoader } from './layouts/Main';

// Library imports
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

// Actions
import { logoutAction } from './actions/Logout';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Main />,
    loader: mainLoader,
    errorElement: <Error />,
    children: [
      {
        index: true,
        element: <Dashboard />,
        loader: dashboardLoader,
        errorElement: <Error />
      },
      {
        path: "logout",
        action: logoutAction
      }
    ]
  }
]);

function App() {

  // <ToastContainer /> it's bugged here.
  return (
    <>
      <RouterProvider router={router} />
      <ToastContainer />
    </>
  )
}

export default App
