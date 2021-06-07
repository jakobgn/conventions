
import { useState } from "react";
import styles from "../styles/Conventions.module.css";
import { useRouter } from "next/router";
import RegisterEvent from "../components/RegisterEvent";
import { useAuth0 } from "@auth0/auth0-react";
import { Convention } from "./api/models";


export default function Conventions({
  conventions,
}: {
  conventions: Array<Convention>;
}) {
  const { isAuthenticated } = useAuth0();
  const router = useRouter();
  const handleConventionClick = (id: number) => {
    router.push("/talks/" + id);
  };
  const [conventionsInternal, setConventions] = useState<Array<Convention>>(conventions);
  const onAddConvention = (convention: Convention) => {
    setConventions([...conventionsInternal,convention])
  }
  return (
    <div className={styles.conventions}>
      <h1>Conventions</h1>
      <div>{isAuthenticated && <RegisterEvent onAddConvention={onAddConvention}></RegisterEvent>}</div>
      {conventionsInternal.map((convention) => (
        <div
          className={styles.convention}
          key={convention.id}
          onClick={() => handleConventionClick(convention.id)}
        >
          <h2 className={styles.title}>{convention.location}</h2>
          <p>
            Date: <strong>{new Date(convention.date).toLocaleDateString()}</strong>
          </p>
        </div>
      ))}
    </div>
  );
}

export async function getStaticProps() {
  const serverUrl = process.env.REACT_APP_SERVER_URL;
  try {
    const response = await (await fetch(`${serverUrl}/conventions`)).json();
    console.log(response)
    return {
      props: { conventions:response },
    };
  } catch (error) {
    return {
      props: { conventions:[] },
    };
  }

}
