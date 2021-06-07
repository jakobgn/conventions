import "../styles/globals.css";
import type { AppProps } from "next/app";
import { Auth0Provider } from "@auth0/auth0-react";
import Layout from "../components/Layout";
function MyApp({ Component, pageProps }: AppProps) {
  const origin =
    typeof window !== "undefined" && window.location.origin
      ? window.location.origin
      : "";
      
  return (
    <Auth0Provider
      domain="jakobgn.eu.auth0.com"
      clientId="xdZgNgzK8AYRxO3gDIRT7sPkWhYLWmpZ"
      audience="conventions"
      redirectUri={origin}
      scope="read:current_user"
    >
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </Auth0Provider>
  );
}
export default MyApp;
