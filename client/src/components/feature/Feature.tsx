import FeatureItem from "./FeatureItem";

const Feature = () => {
  return (
    <>
      <div className="container mx-auto mt-10 mb-4">
        <h1 className="text-xl font-medium mb-7">MOLOPOLY</h1>
        <div className="flex flex-auto overflow-x-scroll md:overflow-hidden gap-4">
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
        </div>
      </div>
    </>
  );
};

export default Feature;
