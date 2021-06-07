import { useAuth0 } from "@auth0/auth0-react";

const LogoutButton = () => {
  const { logout } = useAuth0();
  const origin =
  typeof window !== "undefined" && window.location.origin
    ? window.location.origin
    : "";
  return (
    <button onClick={() => logout({ returnTo: origin })}>
      Log Out
    </button>
  );
};

export default LogoutButton;