
import logo from './logo.svg';
import './App.css';
import routes from './routes';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from "react-router-dom";

const App = ({ }) => {
  const mapRoute = (routes) => {
    var result = null;
    console.log(routes.length);
    if (routes.length > 0) {
      result = routes.map((route, index) => {
        return (
          <Route key={index}
            path={route.path}
            exact={route.exact}
            element={route.main()}
          />
        )
      })
    }
    return <Routes>{result}</Routes>;

  }
  return (
      <Router>
        {mapRoute(routes)}
      </Router>
  )
}
export default App;