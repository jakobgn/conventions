import styles from "../styles/Layout.module.css";
import RegisterButton from "../components/RegisterButton";
import LogoutButton from "../components/LogoutButton";
import { useAuth0 } from "@auth0/auth0-react";

export default function Layout({ children }: { children: React.ReactNode }) {
  const { user, isAuthenticated, isLoading } = useAuth0();
//   if (isLoading) {
//     return <div>Loading ...</div>;
//   }
  return (
    <div className={styles.root}>
      <div className={styles.content}>
        <nav className={styles.nav}>
          {isAuthenticated ? (
            <div className={styles.loginContainer}>
              {user?.email}
              <LogoutButton />
            </div>
          ) : (
            <RegisterButton />
          )}
        </nav>
        {children}
      </div>
    </div>
  );
}
