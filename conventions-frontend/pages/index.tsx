import { conventions, Convention } from "./api/mock";
import styles from "../styles/Conventions.module.css";
import { useRouter } from "next/router";

export default function Conventions({
  conventions,
}: {
  conventions: Array<Convention>;
}) {
  const router = useRouter();
  const handleConventionClick = (id: number) => {
    router.push("/talks/" + id);
  };
  return (
    <div className={styles.conventions}>
      <h1>Conventions</h1>
      {conventions.map((convention) => (
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
  const response = await (await fetch(`${serverUrl}/conventions`)).json();
  console.log(response)
  return {
    props: { conventions:response },
  };
}
